using System;
using System.Collections.Generic;
using System.Text;

namespace PRSTLibrary.Models {
    public class Vendor {



    }
}
/*| Name       | Type    | Null | Len | Unique | PK  | FK  | Def | Gen | Notes |
| ----       | ----    | ---- | --- | ------ | --- | --- | --- | --- | ----- |
| Id         | Integer | No   | N/A | Yes    | Yes | No  | No  | Yes | 1,1   |
| Code       | String  | No   | 30  | Yes    | No  | No  | No  | No  |       |
| Name       | String  | No   | 30  | No     | No  | No  | No  | No  |       |
| Address    | String  | No   | 30  | No     | No  | No  | No  | No  |       |
| City       | String  | No   | 30  | No     | No  | No  | No  | No  |       |
| State      | String  | No   | 2   | No     | No  | No  | No  | No  |       |
| Zip        | String  | No   | 5   | No     | No  | No  | No  | No  |       |
| Phone      | String  | Yes  | 12  | No     | No  | No  | No  | No  |       |
| Email      | String  | Yes  | 255 | No     | No  | No  | No  | No  |       |

Notes:

1. The `Code` column must be unique for all rows though it is not the PK.
