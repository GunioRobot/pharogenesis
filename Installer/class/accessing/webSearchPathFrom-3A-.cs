webSearchPathFrom: string

	| reader result |
	
	reader := string readStream.
	result := OrderedCollection new.
	
	[ reader atEnd ] whileFalse: [ result add: (reader upTo: $;) ].

	WebSearchPath := result.