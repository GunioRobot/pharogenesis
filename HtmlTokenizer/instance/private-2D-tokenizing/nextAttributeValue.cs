nextAttributeValue
	"return the next sequence of alphanumeric characters; used to read in the value part of a tag's attribute, ie <tagname  attribname=attribvalue>"
	"because of the plethora of sloppy web pages, this is EXTREMELY tolerant"
	| c start end |

	"make sure there are at least two characters left"
	pos >= text size ifTrue: [ ^self nextChar asString ].

	"okay, peek at the first character"
	start _ pos.
	c _ text at: start.

	"check whether it's either kind of quote mark"
	(c = $" or: [ c = $' ]) ifTrue: [
		"yes--so find the matching quote mark"
		end _ text indexOf: c startingAt: start+1 ifAbsent: [ text size + 1 ].
		pos _ end+1.
		^text copyFrom: start to: end ].


	"no--go until a space or a $> is seen"
	end _ text indexOfAnyOf: CSAttributeEnders startingAt: start ifAbsent: [ text size + 1 ].
	end _ end - 1.
	pos _ end + 1.
	^text copyFrom: start to: end.