colorString: aColor
	aColor == nil ifTrue: [^ 'nil'].
	Color colorNames do: [:colorName | aColor = (Color perform: colorName)
								ifTrue: [^ 'Color ' , colorName]].
	^ aColor storeString