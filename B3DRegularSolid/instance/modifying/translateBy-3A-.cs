translateBy: amount

  " this method assumes
     1. that vertices does not contain shared instances,
    Any shared instances would be translated more than once, which is clearly wrong. "
  vertices do: [:vertex |   vertex += amount].
  bBox ifNotNil:[bBox _ bBox translateBy: amount].