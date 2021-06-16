/*
 * Checkout API
 *
 * # Changelog All notable changes to the API.  ## 2021-06-01  > new: Support `bambora.mobilepay` payment product type. Extend configuration on > gateway and session to enable MobilePay payment via Bambora Wallet service. The > payment type must be enabled by Bambora. > - [PUT /v1/admin/checkout](#operation/admin_checkout_id_put) > - [POST /v1/session-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions/{session_id}/pay](#operation/checkout_sid_pay_post)  > doc: Fix documentation for payment-token session endpoint. `session` and > `payment_token` are required when creating payment-token session. > - [POST /v1/sessions/payment-token](#operation/checkout_payment_token_session_post)  > new: Support `enable_on_hold`-configuration on session configuration and in checkout configuration > - [POST /v1/session-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post) > - [PUT /v1/admin/checkout](#operation/admin_checkout_id_put)  ## 2021-05-01  > new: Support `bambora.vipps` payment product type. Extend configuration on > gateway and session to enable Vipps payment via Bambora Wallet service. The > payment type must be enabled by Bambora. > - [PUT /v1/admin/gateways/bambora](#operation/admin_checkout_id_gw_bambora_put) > - [PUT /v1/admin/checkout](#operation/admin_checkout_id_put) > - [POST /v1/session-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions/{session_id}/pay](#operation/checkout_sid_pay_post)  > **new**: Support session profile configuration when creating payment-token session > - [POST /v1/sessions/payment-token](#operation/checkout_payment_token_session_post)  > **new**: Extend  shipping_address_callback response with support for updating  > the checkout session in addition to returning available shipping options. This will allow > the callback endpoint to update the content of the order, like changing amount, or > currency or update the items in the order. > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST examples/shipping_address_callback_url](#operation/example_shipping_address_callback_url)   ## 2021-04-01  > **change**: Add support for void on part capture. Void can be used to release > the remaining authorization on a part captured transaction. The support is > limited to `payex.creditcard` transactions. > - [POST /v1/transactions/{id}/void](#operation/transactions_id_void_post)  > **change**: Add support for `language` query parameter when getting payment > operations > - [POST /v1/view/{session_id}/payments/{payment_product_type}](#operation/checkout_sid_payments_product_type_post)  > **change**: Add support Bambora creditcard payment. > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  > **change**: Add support for bypassing the Dintero redirect for in_app-payments, and > redirect from app to app. > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  ## 2021-03-01 > **change** Add support for includes query parameter in session url.callback_url. > `includes` set to session will enable the sessions url.callback_url to include session data in the body. > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  ## 2021-02-01  > **new**: It is now possible to use full ISO 8601 compliant datetimes in date range queries. > Note: If timezone isn't specified, UTC is assumed > Note: To keep things backwards compatible, end-dates with the \"yyyy-mm-dd\" format will be  > shifted forward by a day. > - [GET /v1/transactions](#operation/transactions_get) > - [GET /v1/sessions](#operation/checkout_sessions_get)  > **new**: Add possibility to create myDintero-user in address change  > - [POST /v1/view/{session_id}/session/order/addresses](#operation/checkout_sid_json_order_addresses_put)  > **new**: Extend transaction data with embedded session data > `includes` now supports 'session' >  - [GET /v1/transactions/{id}](#operation/transactions_id_get)  > **new**: Extend Vipps transaction metadata with > `vipps:merchantInfo.merchantSerialNumber`, the Merchant Serial Number > (MSN) that was used when the transaction was initiated.  > **new** Add support for setting settlements on a transaction, one event > per payout to a bank account > - [POST /v1/transactions/events/payout](#operation/transactions_events_payout_post)  > **new**: Version support when updating PayEx gateway configuration. The > new option allows the gateway to be configured with multiple merchant > agreements > - [PUT /v1/admin/gateways/payex](#operation/admin_checkout_id_gw_payex_put) > - [PUT /v1/admin/gateways/payex/override](#operation/admin_checkout_id_gw_override_payex_put)  > **change**: Add support for additional query parameters. > `search` will match on merchant reference's and customer name > `transaction_id` will filter results to include only sessions associated with the provided transaction ids > `created_at.gte` will exclude all sessions created before provided date > `created_at.lte` will exclude all sessions created after provided date > - [GET /v1/sessions](#operation/checkout_sessions_get)  ## 2021-01-01  > **new**: Endpoint for initiating MIT payments > - [POST /v1/sessions/pay](#operation/checkout_session_pay_post)  > **new**: Checkout sessions and profiles supports theming via `configuration.theme` > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /admin/session/profiles](#operation/admin_session_profile_post)  ## 2020-12-01  > **new**: Add support for using external discount codes in Express checkout. > A session can be configured with a `express.discount_code_callback_url` that will be > invoked when the session is updated with a promotion code. The response from > the callback will then be used to adjust the order and shipping options > available. > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST examples/discount_code_callback_url](#operation/example_discount_code_callback_url)  > **new**: Add support for an advance credit check of Collector B2B customers > - [POST /v1/creditchecks](#operation/creditchecks_post)   ## 2020-11-01  > **new**: Add support for overriding Collector gateway settings > - [PUT /v1/admin/gateways/collector/override](#operation/admin_checkout_id_gw_override_collector_put)  > **new** Add support for `collector.invoice_b2b_preapproved` and `collector.installment_b2b_preapproved` payment  > **new** Async transaction operations. The response status from > capture, refund or void can now be `202` if the request was accepted > but the processing has not been completed. > > The transaction with an operation that was accepted will receive a > update later when the processing completes. > The event that completes the operation will include an > `initiate_request_id` property. > You can use the `callback_url` to receive a callback when the > processing completes. > > The status of the transaction will remain unchanged until the processing > of the operation completes. > > - [POST /v1/transactions/{id}/capture](#operation/transactions_id_capture_post) > - [POST /v1/transactions/{id}/refund](#operation/transactions_id_refund_post) > - [POST /v1/transactions/{id}/void](#operation/transactions_id_void_post)  > **new** Add support for callback when transaction is updated. You can now > receive callbacks on captures, refunds and void by including > `report_event=<event>` query parameter in the `callback_url`. > >     https://example.com/callback?report_event=CAPTURE&report_event=REFUND > > > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  ## 2020-10-01  > **new** Added `in_store` as a possible payment channel for > payments in physical stores. > > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  ## 2020-09-01  > **new** Added option for configurating the payment channel. > See `configuration.channel`. The new option add support for > `in_app` channel with appswitch deeplink URL (Vipps). > > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  > **new** Add support for optional `order.discount_lines` when creating > a new sessions. > > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  > **new** Add support for updating a session > - [PUT /v1/sessions/{session_id}](#operation/checkout_session_put) > - [POST /view@{session_id}@session@lock](#operation/checkout_sid_lock)  > `total_income` moved from applicant to top level for instabank.invoice and instabank.installment. > The field is required, but there will be a grace period of two months before it is enforced. > Deprecated `applicant.total_income` > > - [POST /v1/sessions/pay](#operation/checkout_sid_pay_post)  ## 2020-08-01  > **new** Add support for optional `metadata` when creating > a new session. > > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  > **new** Add support for optional `merchant_reference_2` when > creating a new session > > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  > **new** Add support for delayed callback. You can enable the delay callback feature > by including `delay_callback=<seconds>` query parameter in the `callback_url` > >     https://example.com/callback?delay_callback=30 >  ## 2020-07-01  > **new**: Add support for overriding Netaxept gateway settings > - [PUT /v1/admin/gateways/netaxept/override](#operation/admin_checkout_id_gw_override_netaxept_put)  > **new**: Add terminal options for Netaxept creditcard payment. Enable use of > Netaxept hosted checkout, and provided custom configuration.  > **new**: Add support for Netaxept. > - [GET /view/{session_id}/netaxept](#operation/checkout_sid_netaxept_html_get)  > **new**: Add support for overriding PayEx gateway settings > - [PUT /v1/admin/gateways/payex/override](#operation/admin_checkout_id_gw_override_payex_put)  > **new**: Include payment token in transaction details > - [GET /v1/transactions/{id}?includes=card.payment_token](#operation/transactions_id_get)  > **new** Added option for using payment token for payex.creditcard payments > to prefill payment details so the customer (payer) do not need to enter all > these details for every purchase.  > **new** Added option for generating payment token for payex.creditcard > payments, see `configuration.payex.creditcard`. Use the new option to > generate a payment token that can be used in future payments to prefill > the details for the creditcard.  > **new** Added `instabank.postponement` payment type.  > **new** Added `swish.swish` payment type, direct integration with Swish.  ## 2020-06-01  > **change** Add support for `ON_HOLD` transaction status. The new status > is limited to Collector transactions, to signal that the processing > of the transaction is not yet completed. The new status will be used in > cases where Collector performs aditional controls before approving the > payment.  > **new** Add support for setting `merchant_reference_2` to an existing > transaction and search for transactions by `merchant_reference_2`. > > - [PUT /v1/transaction/{transction_id}](#operation/transactions_id_put) > - [GET /v1/transactions](#operation/transactions_get)  ## 2020-05-01  > **new** Add support for POST callback with the authorized transaction > included in the request body. You can enable the POST callback feature > by including `method=POST` query parameter in the `callback_url` > >     https://example.com/callback?method=POST > > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  ## 2020-04-01  > **new** Add support for `instabank.installment` payment  > **changed**: Removed error `capture` from list of valid error added to > the redirect to the `url.redirect_url`. The error was used for payments with > `auto-capture` enabled, and set in case where the auto capture failed. > The merchant can assume the transaction will be captured automatically as > soon as possible when creating a session with `auto-capture` enabled. > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  > **changed**: A callback (when `url.callback_url` is set) will now be sent > as soon as possible after the transaction is `AUTHORIZED`. We will no longer > wait until the transaction `CAPTURED` in case when `auto-capture` is enabled. > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  > **change**: Add support for creating session with Ingenico enabled > - [POST /sessions-profile](#operation/checkout_session_profile_post) > - [POST /sessions](#operation/checkout_session_post) > - [POST /admin/session/profiles](#operation/admin_session_profile_post)  > **change**: Add support for creating session with Ingenico enabled > - [POST /sessions-profile](#operation/checkout_session_profile_post) > - [POST /sessions](#operation/checkout_session_post) > - [POST /admin/session/profiles](#operation/admin_session_profile_post)  > **new** Add support for `collector.invoice_b2b` payment  ## 2020-03-01  > **new** Add support for configuring Ingenico gateway > - [PUT /admin/gateways/ingenico](#operation/admin_checkout_id_gw_ingenico_put)  > **new** Add support for enabling `Dintero-Signature` header for all > system-to-system request sent from Dintero to the merchant > - [POST /v1/admin/signature](#operation/admin_signature_post)  > **fix**: Documentation for endpoint [GET /v1/admin/api-keys](#operation/admin_api_keys_get). > The resource returns a list of api-keys, not a single api-key.  > **new** Add support for `collector.installment` payment  > **new** Add support for putting merchant_terms_url in profile and session > - [POST /v1/admin/session/profiles](#operation/admin_session_profile_post) > - [PUT /v1/admin/session/profiles/{profile_id}](#operation/admin_session_profile_details_put) > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  > **new** Add support for overriding gateway settings > - [PUT /v1/admin/gateways/vipps/override](#operation/admin_checkout_id_gw_override_vipps_put) > - [PUT /v1/admin/gateways/santander/override](#operation/admin_checkout_id_gw_override_santander_put)  ## 2019-12-01  > **new** Add support for `include_session` query parameter > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  > **new** Add support for discount calculation on sessions. > The discounts will be calculated when customer is identified > > Extend the order and transaction items with new properties to > support discount calculation of session: > - `discount_lines` > - `gross_amount` > - `is_change` > - `eligible_for_discount` > > Support calculating and updating session with discount from: > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  > **new** Add store property to `session.order` and transaction. > Adds support for including details about the sales location in the order  > **new** Add `shipping_option` from `session.order` to to `transaction` > - [GET /transactions](#operation/transactions_get) > - [GET /transactions/{id}](#operation/transactions_id_get)  > **changed** Minor changes to the `shipping_option` object(s) in sessions > - [POST /v1/sessions](#operation/checkout_session_post) > - [GET /v1/sessions](#operation/checkout_sessions_get) > - [GET /v1/sessions/{session_id}](#operation/checkout_session_get) > - [GET /view/{session_id}/session](#operation/checkout_sid_json_get)  > **new** Add an endpoint for abandon a checkout payment > - [POST /view/{session_id}/session/abandon](#operation/view_sid_session_abandon_post)  ## 2019-11-01  > **changed**: Express Checkout flow added to sessions > - [POST /v1/sessions](#operation/checkout_session_post) > - [GET /v1/sessions](#operation/checkout_sessions_get) > - [GET /v1/sessions/{session_id}](#operation/checkout_session_get) > - [GET /view/{session_id}/session](#operation/checkout_sid_json_get)  > **new** Update a an Express Checkout session order > - [PUT /view/{session_id}/session](#operation/checkout_sid_json_put)  > **new**: Extend Transaction with optional `billing_address` field.  ## 2019-10-01  > **new**: Extend Transaction Event with correction field > to handle correction of status after operations errors  > **changed**: previously required fields are now optional for `instabank.finance`. > - mortgage_debt > - student_debt > - other_secured_debt  > **changed**: Payments for _payment product type_ `instabank.invoice` now > contain an optional `applicant` object used for sending more details about > the payee. The applicant data will be required for amounts over a limit > specified by Instabank. > - [POST /v1/sessions/{session_id}/pay](#operation/checkout_sid_pay_post)   > **changed**: Payment sessions with `instabank.invoice` now contains an > `require_applicant` boolean flag in the _instabank invoice configuration_ > when getting the session. > - [GET /v1/sessions/{session_id}](#operation/checkout_session_get)  > **changed**: Adds detailed debt array to `instabank.finance`.  ## 2019-09-01  > **changed**: Disabled `instabank.invoice` for amounts less than 500 NOK  > **new**: Filter transaction list by `payment_product_type`: > - instabank.finance > - instabank.invoice > - vipps > - payex.creditcard > - payex.swish  > **new**: Filter transactions list by `card_brand`: > - Visa > - MasterCard  > **new**: Added optional `remember_me` boolean to POST pay request body > when initializing a payment of a session. > - [POST /v1/sessions/{session_id}/pay](#operation/checkout_sid_pay_post)  ## 2019-07-01  > **fix**: `Transaction.status` typo, rename `PARTICALLY_CAPTURED_REFUNDED` to > `PARTIALLY_CAPTURED_REFUNDED`.  > **changed**: replaced `card` payment type with `payex`. The payex > payment type adds support for payment product types: > - payex.creditcard > - payex.swish  > **changed**: Add support for optional custom expires_at parameter when > creating a new session either directly or from a profile. > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  > **changed**: Add support for override of configuration when creating > a new session from a profile. > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  > **new**: support cancel of session > - [POST /v1/sessions/{session_id}/cancel](#operation/checkout_session_cancel_post)  > **changed**: In SessionBase, extend order with `partial_payment` > property that can be used in case where the payment is partial > and the `order.amount` is less or equal to the `order.items.amount`. > - [POST /v1/sessions](#operation/checkout_session_post) > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post)  ## 2019-06-01  > **break**: Pay with `instabank.finance` type requires now additional > properties to comply with new regulations from Finanstilsynet. > - [POST /v1/sessions/{session_id}/pay](#operation/checkout_sid_pay_post) > **changed**: In SessionMeta events, extend event with `details` object > and enumerate the event names available. > - [GET /v1/sessions/{session_id}](#operation/checkout_session_get)  > **changed**: Remove `instabank.installment` and > `instabank.postponement` payment type. The types will no longer be > accepted by: > - [PUT /v1/admin/checkout](#operation/admin_checkout_id_put) > - [PUT /v1/admin/gateways/instabank](#operation/admin_checkout_id_gw_instabank_put) > - [POST /v1/admin/session/profiles](#operation/admin_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  ## 2019-05-01 > In SessionMeta renamed field  `expiry_at` to `expires_at`.  > **new**: PaymentConfiguration extended with optional `auto_capture` boolean field. If set to true the > checkout serivce will automatically capture the payment after the transaction is `AUTHORIZED`.  > **new**: Add support for checkout with SMS. > A SMS with link to the checkout can now be sent when a new > session is created. > See relevant resources for more information. > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)  ## 2019-04-01  > **fix**: Fix documentation for the response from [api-keys](#tag/api-keys) > endpoints. No `gateways` property will be included in response to api-keys > requests.  > **doc**: Document support for JWT Bearer authentication. Use API client > to get an JWT access token. > - [Create Client](https://docs.dintero.com/api.html#operation/aid_auth_clients_post) > - [Get token](https://docs.dintero.com/api.html#operation/aid_auths_oauth_token_post)  ## 2019-03-01  > **break**: Administration of checkout gateways was moved to new > endpoints. Gateway configuration will no longer be supported via > the `PUT /admin/checkout` endpoint. > - [PUT /admin/checkout](#operation/admin_checkout_id_put) > - [POST /admin/gateways/{gateway}/status](#operation/admin_checkout_gw_type_status_post) > - [PUT /admin/gateways/instabank](#operation/admin_checkout_id_gw_instabank_put) > - [PUT /admin/gateways/vipps](#operation/admin_checkout_id_gw_vipps_put) > > **removed**: > - ~`POST /admin/gateways/{gateway}`~ (check gateway status)  > **new**: Extend transaction.event with `created_by` property. > Include the user who created the event, i.e. applied an operation > to the transaction.  ## 2019-01-31  > **new**: Add support for checkout with QR-Code > A QR Code can now be generated for a Checkout Session or a Sale Location. > See relevant resource for more information. > - [POST /v1/locations/{location_id}/qr](#operation/qr_locations_lid_post) > - [POST /v1/sessions/{session_id}/qr](#operation/qr_sessions_sid_post) > - [POST /v1/locations/{location_id}/checkout/{session_id}](#operation/qr_locations_lid_checkout_sid_post) > - [DELETE /v1/locations/{location_id}/checkout/{session_id}](#operation/qr_locations_lid_checkout_sid_delete)  > **new**: Add support for filter transactions with query parameters. > Transactions can now be filtered on: `status`, `payment_product`, > `merchant_reference`, `session_id`, `amount` and `created_at`. > - [GET /v1/transactions](#operation/transactions_get)  ## 2018-11-24  > **new**: Add support for `session.url.callback_url`. Get system-to-system >  notification when session payment is completed. > - [POST /v1/sessions-profile](#operation/checkout_session_profile_post) > - [POST /v1/sessions](#operation/checkout_session_post)    
 *
 * The version of the OpenAPI document: LATEST
 * Contact: integration@dintero.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Dintero.OpenApiClient.Checkout.Client;
using Dintero.OpenApiClient.Checkout.Model;

namespace Dintero.OpenApiClient.Checkout.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIngenicoApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Handle Ingenico webhooks url validation
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <returns></returns>
        void CheckoutIngenicoWebhooksGet(string xGCSWebhooksEndpointVerification);

        /// <summary>
        /// Handle Ingenico webhooks url validation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CheckoutIngenicoWebhooksGetWithHttpInfo(string xGCSWebhooksEndpointVerification);
        /// <summary>
        /// Handle Ingenico webhooks
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <returns></returns>
        void CheckoutIngenicoWebhooksPost(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data);

        /// <summary>
        /// Handle Ingenico webhooks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CheckoutIngenicoWebhooksPostWithHttpInfo(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data);
        /// <summary>
        /// Handle redirect from payment
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <returns></returns>
        void CheckoutSidIngenicoRedirectGet(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string));

        /// <summary>
        /// Handle redirect from payment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CheckoutSidIngenicoRedirectGetWithHttpInfo(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIngenicoApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Handle Ingenico webhooks url validation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CheckoutIngenicoWebhooksGetAsync(string xGCSWebhooksEndpointVerification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Handle Ingenico webhooks url validation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CheckoutIngenicoWebhooksGetWithHttpInfoAsync(string xGCSWebhooksEndpointVerification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Handle Ingenico webhooks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CheckoutIngenicoWebhooksPostAsync(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Handle Ingenico webhooks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CheckoutIngenicoWebhooksPostWithHttpInfoAsync(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Handle redirect from payment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CheckoutSidIngenicoRedirectGetAsync(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Handle redirect from payment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CheckoutSidIngenicoRedirectGetWithHttpInfoAsync(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIngenicoApi : IIngenicoApiSync, IIngenicoApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IngenicoApi : IIngenicoApi
    {
        private Dintero.OpenApiClient.Checkout.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngenicoApi"/> class.
        /// </summary>
        /// <returns></returns>
        public IngenicoApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngenicoApi"/> class.
        /// </summary>
        /// <returns></returns>
        public IngenicoApi(String basePath)
        {
            this.Configuration = Dintero.OpenApiClient.Checkout.Client.Configuration.MergeConfigurations(
                Dintero.OpenApiClient.Checkout.Client.GlobalConfiguration.Instance,
                new Dintero.OpenApiClient.Checkout.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Dintero.OpenApiClient.Checkout.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Dintero.OpenApiClient.Checkout.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Dintero.OpenApiClient.Checkout.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngenicoApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public IngenicoApi(Dintero.OpenApiClient.Checkout.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Dintero.OpenApiClient.Checkout.Client.Configuration.MergeConfigurations(
                Dintero.OpenApiClient.Checkout.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Dintero.OpenApiClient.Checkout.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Dintero.OpenApiClient.Checkout.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Dintero.OpenApiClient.Checkout.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngenicoApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public IngenicoApi(Dintero.OpenApiClient.Checkout.Client.ISynchronousClient client, Dintero.OpenApiClient.Checkout.Client.IAsynchronousClient asyncClient, Dintero.OpenApiClient.Checkout.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Dintero.OpenApiClient.Checkout.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Dintero.OpenApiClient.Checkout.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Dintero.OpenApiClient.Checkout.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Dintero.OpenApiClient.Checkout.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Dintero.OpenApiClient.Checkout.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Handle Ingenico webhooks url validation 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <returns></returns>
        public void CheckoutIngenicoWebhooksGet(string xGCSWebhooksEndpointVerification)
        {
            CheckoutIngenicoWebhooksGetWithHttpInfo(xGCSWebhooksEndpointVerification);
        }

        /// <summary>
        /// Handle Ingenico webhooks url validation 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Dintero.OpenApiClient.Checkout.Client.ApiResponse<Object> CheckoutIngenicoWebhooksGetWithHttpInfo(string xGCSWebhooksEndpointVerification)
        {
            // verify the required parameter 'xGCSWebhooksEndpointVerification' is set
            if (xGCSWebhooksEndpointVerification == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'xGCSWebhooksEndpointVerification' when calling IngenicoApi->CheckoutIngenicoWebhooksGet");

            Dintero.OpenApiClient.Checkout.Client.RequestOptions localVarRequestOptions = new Dintero.OpenApiClient.Checkout.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-GCS-Webhooks-Endpoint-Verification", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(xGCSWebhooksEndpointVerification)); // header parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", this.Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/events/gateways/ingenico/transaction/hooks", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIngenicoWebhooksGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Handle Ingenico webhooks url validation 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CheckoutIngenicoWebhooksGetAsync(string xGCSWebhooksEndpointVerification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await CheckoutIngenicoWebhooksGetWithHttpInfoAsync(xGCSWebhooksEndpointVerification, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Handle Ingenico webhooks url validation 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSWebhooksEndpointVerification"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Dintero.OpenApiClient.Checkout.Client.ApiResponse<Object>> CheckoutIngenicoWebhooksGetWithHttpInfoAsync(string xGCSWebhooksEndpointVerification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xGCSWebhooksEndpointVerification' is set
            if (xGCSWebhooksEndpointVerification == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'xGCSWebhooksEndpointVerification' when calling IngenicoApi->CheckoutIngenicoWebhooksGet");


            Dintero.OpenApiClient.Checkout.Client.RequestOptions localVarRequestOptions = new Dintero.OpenApiClient.Checkout.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-GCS-Webhooks-Endpoint-Verification", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(xGCSWebhooksEndpointVerification)); // header parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", this.Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/events/gateways/ingenico/transaction/hooks", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIngenicoWebhooksGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Handle Ingenico webhooks 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <returns></returns>
        public void CheckoutIngenicoWebhooksPost(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data)
        {
            CheckoutIngenicoWebhooksPostWithHttpInfo(xGCSSignature, xGCSKeyId, data);
        }

        /// <summary>
        /// Handle Ingenico webhooks 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Dintero.OpenApiClient.Checkout.Client.ApiResponse<Object> CheckoutIngenicoWebhooksPostWithHttpInfo(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data)
        {
            // verify the required parameter 'xGCSSignature' is set
            if (xGCSSignature == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'xGCSSignature' when calling IngenicoApi->CheckoutIngenicoWebhooksPost");

            // verify the required parameter 'xGCSKeyId' is set
            if (xGCSKeyId == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'xGCSKeyId' when calling IngenicoApi->CheckoutIngenicoWebhooksPost");

            // verify the required parameter 'data' is set
            if (data == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'data' when calling IngenicoApi->CheckoutIngenicoWebhooksPost");

            Dintero.OpenApiClient.Checkout.Client.RequestOptions localVarRequestOptions = new Dintero.OpenApiClient.Checkout.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-GCS-Signature", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(xGCSSignature)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-GCS-KeyId", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(xGCSKeyId)); // header parameter
            localVarRequestOptions.Data = data;

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", this.Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/events/gateways/ingenico/transaction/hooks", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIngenicoWebhooksPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Handle Ingenico webhooks 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CheckoutIngenicoWebhooksPostAsync(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await CheckoutIngenicoWebhooksPostWithHttpInfoAsync(xGCSSignature, xGCSKeyId, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Handle Ingenico webhooks 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xGCSSignature"></param>
        /// <param name="xGCSKeyId"></param>
        /// <param name="data">Content of webhook event</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Dintero.OpenApiClient.Checkout.Client.ApiResponse<Object>> CheckoutIngenicoWebhooksPostWithHttpInfoAsync(string xGCSSignature, string xGCSKeyId, IngenicoWebhookEvent data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xGCSSignature' is set
            if (xGCSSignature == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'xGCSSignature' when calling IngenicoApi->CheckoutIngenicoWebhooksPost");

            // verify the required parameter 'xGCSKeyId' is set
            if (xGCSKeyId == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'xGCSKeyId' when calling IngenicoApi->CheckoutIngenicoWebhooksPost");

            // verify the required parameter 'data' is set
            if (data == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'data' when calling IngenicoApi->CheckoutIngenicoWebhooksPost");


            Dintero.OpenApiClient.Checkout.Client.RequestOptions localVarRequestOptions = new Dintero.OpenApiClient.Checkout.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-GCS-Signature", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(xGCSSignature)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-GCS-KeyId", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(xGCSKeyId)); // header parameter
            localVarRequestOptions.Data = data;

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", this.Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/events/gateways/ingenico/transaction/hooks", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIngenicoWebhooksPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Handle redirect from payment 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <returns></returns>
        public void CheckoutSidIngenicoRedirectGet(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string))
        {
            CheckoutSidIngenicoRedirectGetWithHttpInfo(sessionId, redirectRef, RETURNMAC, hostedCheckoutId);
        }

        /// <summary>
        /// Handle redirect from payment 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Dintero.OpenApiClient.Checkout.Client.ApiResponse<Object> CheckoutSidIngenicoRedirectGetWithHttpInfo(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'sessionId' when calling IngenicoApi->CheckoutSidIngenicoRedirectGet");

            // verify the required parameter 'redirectRef' is set
            if (redirectRef == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'redirectRef' when calling IngenicoApi->CheckoutSidIngenicoRedirectGet");

            Dintero.OpenApiClient.Checkout.Client.RequestOptions localVarRequestOptions = new Dintero.OpenApiClient.Checkout.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/html"
            };

            var localVarContentType = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("session_id", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(sessionId)); // path parameter
            localVarRequestOptions.PathParameters.Add("redirect_ref", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(redirectRef)); // path parameter
            if (RETURNMAC != null)
            {
                localVarRequestOptions.QueryParameters.Add(Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToMultiMap("", "RETURNMAC", RETURNMAC));
            }
            if (hostedCheckoutId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToMultiMap("", "hostedCheckoutId", hostedCheckoutId));
            }

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", this.Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/sessions/{session_id}/ingenico/redirect/{redirect_ref}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutSidIngenicoRedirectGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Handle redirect from payment 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CheckoutSidIngenicoRedirectGetAsync(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await CheckoutSidIngenicoRedirectGetWithHttpInfoAsync(sessionId, redirectRef, RETURNMAC, hostedCheckoutId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Handle redirect from payment 
        /// </summary>
        /// <exception cref="Dintero.OpenApiClient.Checkout.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">The session ID</param>
        /// <param name="redirectRef"></param>
        /// <param name="RETURNMAC"> (optional)</param>
        /// <param name="hostedCheckoutId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Dintero.OpenApiClient.Checkout.Client.ApiResponse<Object>> CheckoutSidIngenicoRedirectGetWithHttpInfoAsync(string sessionId, string redirectRef, string RETURNMAC = default(string), string hostedCheckoutId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'sessionId' when calling IngenicoApi->CheckoutSidIngenicoRedirectGet");

            // verify the required parameter 'redirectRef' is set
            if (redirectRef == null)
                throw new Dintero.OpenApiClient.Checkout.Client.ApiException(400, "Missing required parameter 'redirectRef' when calling IngenicoApi->CheckoutSidIngenicoRedirectGet");


            Dintero.OpenApiClient.Checkout.Client.RequestOptions localVarRequestOptions = new Dintero.OpenApiClient.Checkout.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/html"
            };


            var localVarContentType = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Dintero.OpenApiClient.Checkout.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("session_id", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(sessionId)); // path parameter
            localVarRequestOptions.PathParameters.Add("redirect_ref", Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToString(redirectRef)); // path parameter
            if (RETURNMAC != null)
            {
                localVarRequestOptions.QueryParameters.Add(Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToMultiMap("", "RETURNMAC", RETURNMAC));
            }
            if (hostedCheckoutId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Dintero.OpenApiClient.Checkout.Client.ClientUtils.ParameterToMultiMap("", "hostedCheckoutId", hostedCheckoutId));
            }

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", this.Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/sessions/{session_id}/ingenico/redirect/{redirect_ref}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutSidIngenicoRedirectGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
