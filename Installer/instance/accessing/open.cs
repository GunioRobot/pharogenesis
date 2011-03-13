open
	
self sm ifTrue: [ self classSMLoader open ].
self mc ifNotNil: [self mcRepository morphicOpen: nil ].