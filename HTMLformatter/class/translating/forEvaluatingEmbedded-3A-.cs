forEvaluatingEmbedded: stringOrStream
	"stringOrStream is text with <?expr?> expressions intermingled.  This creates a HTLMLformatter instance which will substitute the <?expr?> expressions with the value of the argument (named request), and which leaves all other text in stringOrStream alone"

	| blockStream sourceStream doingEval ch |

	blockStream _ WriteStream on: String new.
 	blockStream nextPutAll: '[ :request :output | output nextPutAll: '''.

	(stringOrStream isKindOf: Stream)
		ifTrue: [sourceStream := stringOrStream]
		ifFalse: [sourceStream := ReadStream on: stringOrStream].

	doingEval _ false.

	[sourceStream atEnd] whileFalse:  [
		ch := sourceStream next.
		(doingEval not and: [ ch = $<  and: [ sourceStream peek = $? ]]) ifTrue: [
			"beginning of an <?...?> expression"
			blockStream nextPutAll: '''.  output nextPutAll: ['.
			sourceStream next.  "Skip the ?" 
			doingEval _ true]
		ifFalse: [
		(doingEval and: [ ch = $? and: [ sourceStream peek = $> ]]) ifTrue: [
			"end of a <?...?> expression"
			blockStream nextPutAll: '] value asString.  output nextPutAll: '''.
			sourceStream next.  "Skip the >" 
			doingEval _ false.]
		ifFalse: [
			"normal char"
			blockStream nextPut: ch.
			(doingEval not and: [ ch = $' ]) ifTrue: [ "double $' marks"  blockStream nextPut: $' ] ] ] ].


	"end the block"
	doingEval
		ifTrue: [ blockStream nextPutAll: '] value asString' ]
		ifFalse: [ blockStream nextPutAll: '''' ].
	blockStream nextPutAll: ']'.

	^HTMLformatter new formattingBlock: (Compiler evaluate: blockStream contents)