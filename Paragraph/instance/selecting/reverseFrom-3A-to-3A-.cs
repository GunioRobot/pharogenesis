reverseFrom: characterBlock1 to: characterBlock2 
	"Reverse area between the two character blocks given as arguments."
	| visibleRectangle initialRectangle interiorRectangle finalRectangle |
	characterBlock1 = characterBlock2
		ifTrue: [^ CaretForm  "Use a caret to indicate null selection"
					displayOn: destinationForm
					at: characterBlock1 topLeft + (0 @ textStyle baseline)
					clippingBox: clippingRectangle
					rule: (Display depth>8
							ifTrue: [9 "not-reverse"]
							ifFalse: [Form reverse])
					fillColor: nil].
	visibleRectangle _ 
		(clippingRectangle intersect: compositionRectangle)
			"intersect: destinationForm boundingBox" "not necessary".
	characterBlock1 top = characterBlock2 top
		ifTrue: [characterBlock1 left < characterBlock2 left
					ifTrue: 
						[initialRectangle _ 
							(characterBlock1 topLeft corner: characterBlock2 bottomLeft)
								intersect: visibleRectangle]
					ifFalse: 
						[initialRectangle _ 
							(characterBlock2 topLeft corner: characterBlock1 bottomLeft)
								intersect: visibleRectangle]]
		ifFalse: [characterBlock1 top < characterBlock2 top
					ifTrue: 
						[initialRectangle _ 
							(characterBlock1 topLeft 
								corner: visibleRectangle right @ characterBlock1 bottom)
								intersect: visibleRectangle.
						characterBlock1 bottom = characterBlock2 top
							ifTrue: 
								[finalRectangle _ 
									(visibleRectangle left @ characterBlock2 top 
										corner: characterBlock2 bottomLeft)
										intersect: visibleRectangle]
							ifFalse: 
								[interiorRectangle _ 
									(visibleRectangle left @ characterBlock1 bottom
										corner: visibleRectangle right 
														@ characterBlock2 top)
										intersect: visibleRectangle.
								finalRectangle _ 
									(visibleRectangle left @ characterBlock2 top 
										corner: characterBlock2 bottomLeft)
										intersect: visibleRectangle]]
				ifFalse: 
					[initialRectangle _ 
						(visibleRectangle left @ characterBlock1 top 
							corner: characterBlock1 bottomLeft)
							intersect: visibleRectangle.
					characterBlock1 top = characterBlock2 bottom
						ifTrue: 
							[finalRectangle _ 
								(characterBlock2 topLeft 
									corner: visibleRectangle right 
												@ characterBlock2 bottom)
									intersect: visibleRectangle]
						ifFalse: 
							[interiorRectangle _ 
								(visibleRectangle left @ characterBlock2 bottom 
									corner: visibleRectangle right @ characterBlock1 top)
									intersect: visibleRectangle.
							finalRectangle _ 
								(characterBlock2 topLeft 
									corner: visibleRectangle right 
												@ characterBlock2 bottom)
									intersect: visibleRectangle]]].
	self hiliteRect: initialRectangle.
	self hiliteRect: interiorRectangle.
	self hiliteRect: finalRectangle.