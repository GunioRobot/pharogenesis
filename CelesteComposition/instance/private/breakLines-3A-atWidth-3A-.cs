breakLines: aString  atWidth: width
	"break lines in the given string into shorter lines"
	| result start end atAttachment |

	result _ WriteStream on: (String new: (aString size * 50 // 49)).

	atAttachment _ false.
	aString asString linesDo: [ :line | 
		(line beginsWith: '====') ifTrue: [ atAttachment _ true ].
		atAttachment ifTrue: [
			"at or after an attachment line; no more wrapping for the rest of the message"
			result nextPutAll: line.  result cr ]
		ifFalse: [
			(line beginsWith: '>') ifTrue: [
				"it's quoted text; don't wrap it"
				result nextPutAll: line. result cr. ]
			ifFalse: [
				"regular old line.  Wrap it to multiple lines"
				start _ 1.
					"output one shorter line each time through this loop"
				[ start + width <= line size ] whileTrue: [
	
					"find the end of the line"
					end _ start + width - 1.
					[end >= start and: [ (line at: (end+1)) isSeparator not ]] whileTrue: [
						end _ end - 1 ].
					end < start ifTrue: [
						"a word spans the entire width!"
						end _ start + width - 1 ].

					"copy the line to the output"
					result nextPutAll: (line copyFrom: start to: end).
					result cr.

					"get ready for next iteration"
					start _ end+1.
					(line at: start) isSeparator ifTrue: [ start _ start + 1 ].
				].

				"write out the final part of the line"
				result nextPutAll: (line copyFrom: start to: line size).
				result cr.
			].
		].
	].

	^result contents