versionHighlight: aStringCollection with: aMorphCollection
	| emphasis |
	aStringCollection with: aMorphCollection do: [ :string :entry |
		emphasis _ (loaded includes: string) ifTrue: [ 4 "underlined" ] ifFalse: [ 0 ].
		(older includes: string) ifFalse: [emphasis _ emphasis + 1].
		entry emphasis: emphasis ]