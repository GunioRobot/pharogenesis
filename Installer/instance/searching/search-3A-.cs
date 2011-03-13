search: aMatch

self sm ifTrue: [ ^ self smSearch: ('*',aMatch,'*') ].
self mc ifTrue: [ ^ self mcSearch: ('*',aMatch,'*')  ].
self wsm ifNotNil: [ ^ self wsmSearch: ('*',aMatch,'*')  ].

^'search type not supported'