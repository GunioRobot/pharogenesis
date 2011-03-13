resolveRelativeURI: aURI
	| relativeURI newAuthority newPath pathComponents newURI relComps |
	relativeURI _ aURI asURI.

	relativeURI isAbsolute
		ifTrue: [^relativeURI].

	relativeURI authority
		ifNil: [
			newAuthority _ self authority.
			(relativeURI path beginsWith: '/')
				ifTrue: [newPath _ relativeURI path]
				ifFalse: [
					pathComponents _ (self path copyUpToLast: $/) findTokens: $/.
					relComps _ relativeURI pathComponents.
					relComps removeAllSuchThat: [:each | each = '.'].
					pathComponents addAll: relComps.
					pathComponents removeAllSuchThat: [:each | each = '.'].
					self removeComponentDotDotPairs: pathComponents.
					newPath _ self buildAbsolutePath: pathComponents.
					((relComps isEmpty
						or: [relativeURI path last == $/ ]
						or: [(relativeURI path endsWith: '/..') or: [relativeURI path = '..']]
						or: [relativeURI path endsWith: '/.' ])
						and: [newPath size > 1])
						ifTrue: [newPath _ newPath , '/']]]
		ifNotNil: [
			newAuthority _ relativeURI authority.
			newPath _ relativeURI path].

	newURI _ String streamContents: [:stream |
		stream nextPutAll: self scheme.
		stream nextPut: $: .
		newAuthority notNil
			ifTrue: [
				stream nextPutAll: '//'.
				newAuthority printOn: stream].
		newPath notNil
			ifTrue: [stream nextPutAll: newPath].
		relativeURI query notNil
			ifTrue: [stream nextPutAll: relativeURI query].
		relativeURI fragment notNil
			ifTrue: [
				stream nextPut: $# .
				stream nextPutAll: relativeURI fragment]].
	^newURI asURI