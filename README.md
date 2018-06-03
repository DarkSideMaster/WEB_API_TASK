
## WEB API hierarchical tree (ASP.NET Core)

## This WEB API was created use ASP.NET Core technology. And can help you create a hierarchical tree structure to organize your assets in your enterprise.  In response you will receive a JSON of the following structure:

```json
 "id": 1,
    "name": "Enterprise",
    "organizations": [
        {
            "id": 1,
            "name": "Organization",
            "code": null,
            "type": null,
            "generalPartnership": false,
            "limitedPartnership": false,
            "limitedLiabilityCompany": false,
            "incorporatedCompany": false,
            "owner": false,
            "other": null,
            "enterpriseId": 1,
            "countries": [
                {
                    "id": 1,
                    "name": "Ukraine",
                    "code": 0,
                    "organizationId": 1,
                    "businesses": [
                        {
                            "id": 1,
                            "name": "GIS",
                            "countryId": 1,
                            "families": [
                                {
                                    "id": 1,
                                    "name": "Cloud",
                                    "buisnessId": 0,
                                    "offerings": [
                                        {
                                            "id": 1,
                                            "name": "Cloud Compute",
                                            "familyId": 1,
                                            "departments": [
                                                {
                                                    "id": 1,
                                                    "name": "Department C",
                                                    "offeringId": 1,
                                                    "users": [
                                                        {
                                                            "id": 1,
                                                            "name": "Ivan",
                                                            "surname": null,
                                                            "email": null,
                                                            "adress": null,
                                                            "departmentId": 1
                                                        }
                                                    ]
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                }
            ]
        }
    ]
}
```

Also, this WEB API can create, delete or update your entity in hierarchical tree. But for this operation, you must be authorized using Google account. 

*Note: GET request does not require authorization. Also, this example request is valid for all entities in the API.


# GET all

Get the details of the currently EnterPrise Tree.

**URL** : `/api/Enterprise/All`

**Method** : `GET`

**Auth required** : NO

## Success Response

**Code** : `200 OK`

**Content examples**

```json
[
    {
        "id": 1,
        "name": "Enterprise",
        "organizations": null
    }
]

```


# Create 

Creates new entity in your EnterprieTree.

**URL** : `/api/Enterprise/Create?Id=2&Name=Enterprise2`

**Method** : `POST`

**Auth required** : YES

## Success Response

**Code** : `200 OK`

**Content examples**


```json
    {
        "id": 1,
        "name": "Enterprise",
        "organizations": null
    },
    {
        "id": 2,
        "name": "Enterprise2",
        "organizations": null
    }
```

## Update

Update and save the existing entity in your Enterprise Tree.

**URL** : `/api/Enterprise/Update?Id=1&Name=ChangedEnterpriseName`

**Method** : `POST`

**Auth required** : YES

## Success Response

**Code** : `200 OK`

**Content examples**


```json
    {
        "id": 1,
        "name": "ChangedEnterpriseName",
        "organizations": null
    }
```

## Delete

Deleting the existing entity in your Enterprise Tree.

**URL** : `api/Enterprise/Delete?Id=2`

**Method** : `POST`

**Auth required** : YES

## Success Response

**Code** : `200 OK`

**Content examples**

```json
    {
        "id": 1,
        "name": "Enterprise",
        "organizations": null
    }
```
