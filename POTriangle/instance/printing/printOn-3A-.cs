printOn: aStream 
self type ifNotNil: [self type first asString printOn: aStream].
			self edges do: 
		[:edge | 
		edge origin printOn: aStream]