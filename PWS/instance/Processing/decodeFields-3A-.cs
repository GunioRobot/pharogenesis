decodeFields: aString
  "Convert the form fields in aString to a query dictionary."

  | query dict i key value |

  query := aString findTokens: '&'.
  dict := Dictionary new.
  query do: [ :tag |
    i := tag indexOf: $=.
    key := tag copyFrom: 1 to: i - 1.
    value := i < tag size ifTrue: [ self unEscape: (tag copyFrom: i + 1 to: tag size) ] ifFalse: [ nil ].
    (dict includesKey: key)
     ifFalse: [ dict at: key put: value ]
     ifTrue: [
      ((dict at: key) isKindOf: String) 
		ifTrue: [ dict at: key put: (OrderedCollection with: (dict at: key)) ].
      (dict at: key) add: value
     ]
  ].
  ^dict