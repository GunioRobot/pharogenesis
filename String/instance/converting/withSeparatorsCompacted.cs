withSeparatorsCompacted
	"replace each sequences of whitespace by a single space character"
	| out pos textEnd |

	self isEmpty ifTrue: [ ^self ].

	out _ WriteStream on: (String new: self size).
	pos _ 1.   "current position in a scan through aString"


	"handle the case of initial separators"
	self first isSeparator ifTrue: [
		out nextPut: Character space.
		pos _ self indexOfAnyOf: CSNonSeparators ifAbsent: [ self size + 1 ] ].


	"central loop: handle a segment of text, followed possibly by a segment of whitespace"
	[ pos <= self size ] whileTrue: [ 
		"handle a segment of text..."

		textEnd _ self 
			indexOfAnyOf: CSSeparators
			startingAt: pos 
			ifAbsent: [ self size + 1 ].

		textEnd _ textEnd - 1.
		out nextPutAll: (self copyFrom: pos to: textEnd).
		pos _ textEnd + 1.

		pos <= self size ifTrue: [
			pos _ self 
				indexOfAnyOf: CSNonSeparators
				startingAt: pos
				ifAbsent: [ self size + 1 ].

			out nextPut: Character space  ] ].

	^out contents