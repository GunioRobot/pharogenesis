fromString: aString
	"parse an IRC message from its network format"
	| remainder trailerStart trailer tokens command  arguments prefix idx |

	remainder _ aString.

	"strip the CRLF"
	idx _ remainder indexOf: Character cr.
	idx > 0 ifTrue: [ remainder _ remainder copyFrom: 1 to: idx-1 ].
	idx _ remainder indexOf: Character lf.
	idx > 0 ifTrue: [ remainder _ remainder copyFrom: 1 to: idx-1 ].


	"check if there is a trailer"
	trailerStart _ remainder indexOf: $: startingAt: 2 ifAbsent: [0].
	trailerStart > 0 ifTrue: [
		trailer _ remainder copyFrom: trailerStart+1 to: remainder size.
		remainder _ remainder copyFrom: 1 to: trailerStart-1 ].

	"divide the rest of the string up between spaces"
	tokens _ remainder findTokens: ' '.

	"the command is the first token..."
	command _ tokens removeFirst.
	command first = $: ifTrue: [
		"...unless it starts with a $:, in which case there is a prefix and the command is the second token"
		prefix _ command copyFrom: 2 to: command size.  "copy without the leading :"
		command _ tokens removeFirst ].

	"the arguments are the remaining tokens, plus the trailer if any"
	arguments _ tokens.
	trailer ifNotNil: [ arguments _ arguments copyWith: trailer ].

	^self prefix: prefix  command: command  arguments: arguments.