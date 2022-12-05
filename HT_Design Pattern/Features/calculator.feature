Feature: calculator

A short summary of the feature

@tag1
Scenario Outline: Number of cake pieces left 
  Given there are <start> in a cake
  When I ate <eat> pieces from the cake
  Then the remaining peices of cake are <left> 

 Examples:
    | start | eat | left |
    | 4     | 1   | 3    |
    | 8     | 3   | 5    |
    | 10    | 4  | 6    |

