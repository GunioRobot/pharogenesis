objectsInField: fieldName
  "Extract the array of objects denoted by 'fieldName', return an empty array if there are none."

  | sel |
  sel := fields at: fieldName ifAbsent: [ ^#() ].
  (sel isKindOf: Array) ifFalse: [ sel := { sel } ].
  ^sel collect: [ :s | self objectFromString: s ]
