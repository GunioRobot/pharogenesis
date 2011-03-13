closeHtmlAttributes: anArray on: aStream 
	anArray
		do: [:each | each closeHtmlOn: aStream].