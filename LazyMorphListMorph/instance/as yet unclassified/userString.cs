userString
	"Do I have a text string to be searched on?"

	|usm|
	^ String streamContents: [:strm |
		1 to: self getListSize do: [:i |
			usm := (self getListItem: i) submorphs detect: [:m | m userString notNil] ifNone: [].
			strm nextPutAll: (usm ifNil: [''] ifNotNil: [usm userString]); cr]]