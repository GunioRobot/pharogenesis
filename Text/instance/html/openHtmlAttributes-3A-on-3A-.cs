openHtmlAttributes: anArray on: aStream 
	anArray
		do: [:each | each openHtmlOn: aStream ]