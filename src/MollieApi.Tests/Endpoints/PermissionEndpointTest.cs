using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class PermissionEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetPermissionIds()
        {
            await TestGetPermissionId("payments.read");
            await TestGetPermissionId("payments.write");
            await TestGetPermissionId("refunds.read");
            await TestGetPermissionId("refunds.write");
            await TestGetPermissionId("customers.read");
            await TestGetPermissionId("customers.write");
            await TestGetPermissionId("mandates.read");
            await TestGetPermissionId("mandates.write");
            await TestGetPermissionId("subscriptions.read");
            await TestGetPermissionId("subscriptions.write");
            await TestGetPermissionId("profiles.read");
            await TestGetPermissionId("profiles.write");
            await TestGetPermissionId("invoices.read");
            await TestGetPermissionId("invoices.write");
            await TestGetPermissionId("settlements.read");
            await TestGetPermissionId("settlements.write");
            await TestGetPermissionId("orders.read");
            await TestGetPermissionId("orders.write");
            await TestGetPermissionId("organizations.read");
            await TestGetPermissionId("organizations.write");
        }

        public async Task TestGetPermissionId(string permissionId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/permissions/" + permissionId)
            };

            var responseContent = new Permission
            {
                Resource = "permission",
                Id = permissionId,
                Description = "Some dummy permission description",
                Granted = true,
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/permissions/{permissionId}"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/permissions-api/get-permission"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var permission = await _apiClient.Permissions.Get(permissionId);

            AssertPermission(permission, permissionId);
        }

        [TestMethod]
        public async Task TestListPermissions()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/permissions")
            };

            var responseContent = new PermissionCollection
            {
                new Permission
                {
                    Resource = "permission",
                    Id = "payments.write",
                    Description = "Some dummy permission description",
                    Granted = true,
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri($"https://api.mollie.com/v2/permissions/payments.write"),
                            Type = "application/hal+json"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/permissions-api/get-permission"),
                            Type = "text/html"
                        }
                    }
                },
                new Permission
                {
                    Resource = "permission",
                    Id = "payments.read",
                    Description = "Some dummy permission description",
                    Granted = true,
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri($"https://api.mollie.com/v2/permissions/payments.read"),
                            Type = "application/hal+json"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/permissions-api/get-permission"),
                            Type = "text/html"
                        }
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/permissions-api/list-permissions"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/permissions"),
                    Type = "application/hal+json"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var permissions = await _apiClient.Permissions.All();

            Assert.IsInstanceOfType(permissions, typeof(PermissionCollection));

            Assert.AreEqual(2, permissions.Count);

            AssertPermission(permissions[0], "payments.write");
            AssertPermission(permissions[1], "payments.read");
        }

        private void AssertPermission(Permission permission, string permissionId)
        {
            Assert.IsInstanceOfType(permission, typeof(Permission));
            Assert.AreEqual("permission", permission.Resource);
            Assert.AreEqual(permissionId, permission.Id);
            Assert.AreEqual("Some dummy permission description", permission.Description);
            Assert.IsTrue(permission.Granted);
            Assert.AreEqual(new Url($"https://api.mollie.com/v2/permissions/{permissionId}", "application/hal+json"), permission.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/permissions-api/get-permission", "text/html"), permission.Links.Documentation);
        }
    }
}
