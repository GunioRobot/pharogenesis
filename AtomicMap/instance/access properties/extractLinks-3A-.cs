extractLinks: aSymbolList 
	| result link |
	result _ Bag new.
	aSymbolList
		do: [:item | 
			link _ nil.
			"Create a link depending the kind"
			item = #n
				ifTrue: [link _ AtomicMap N].
			item = #ne
				ifTrue: [link _ AtomicMap NE].
			item = #e
				ifTrue: [link _ AtomicMap E].
			item = #se
				ifTrue: [link _ AtomicMap SE].
			item = #s
				ifTrue: [link _ AtomicMap S].
			item = #sw
				ifTrue: [link _ AtomicMap SW].
			item = #w
				ifTrue: [link _ AtomicMap W].
			item = #nw
				ifTrue: [link _ AtomicMap NW].
			link
				
				ifNotNil: [result add: link]].
	^ result