entities

^ Entities ifNil: [ Entities := 
"enough entities to be going on with"
  Dictionary new.
Entities at: 'lt' put: '<';
	at: 'gt' put: '>';
	at: 'amp' put: '&';
	at: 'star' put: '*';
	at: 'quot' put: '"';
	at: 'nbsp' put: ' ';
 	yourself
]

 