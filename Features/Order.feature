Feature: Ordering and calculation bill for group people

    Scenario Outline: Ordering food by group of people before 7 pm
        Given a group of 4 people order
            | Starters | Mains | Drinks | IsBefore7pm   |
            | 4        | 4     | 4      | <IsBefore7pm> |
        When The bill is requested via the endpoint
        Then The calculated sum of bill is correct in the response

        Examples:
            | IsBefore7pm |
            | true        |
            | false       |

    Scenario: Ordering food by group of people joining later to main group of people
        Given a group of 2 people order
            | Starters | Mains | Drinks | IsBefore7pm |
            | 1        | 2     | 2      | true        |
        When The bill is requested via the endpoint
        Then The calculated sum of bill is correct in the response
        When a group of 2 people is joined and order
            | Starters | Mains | Drinks | IsBefore7pm |
            | 1        | 2     | 2      | true        |
        When The bill is requested via the endpoint
        Then The calculated sum of bill is correct in the response

    Scenario Outline: Canceling order by some of the people from the group
        Given a group of 4 people order
            | Starters | Mains | Drinks | IsBefore7pm   |
            | 1        | 1     | 4      | <IsBefore7pm> |
        When The bill is requested via the endpoint
        Then The calculated sum of bill is correct in the response
        When Some people from the group cancel order
            | Starters | Mains | Drinks | IsBefore7pm   |
            | 0        | 0     | 1      | <IsBefore7pm> |
        When The bill is requested via the endpoint
        Then The calculated sum of bill is correct in the response

        Examples:
            | IsBefore7pm |
            | true        |
            | false       |