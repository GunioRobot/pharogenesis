nextName
	"return the next sequence of alphanumeric characters"
	"because of the plethora of sloppy web pages, this also accepts most non-space characters"
	| start end |

	start _ pos.
	end _ text indexOfAnyOf: CSNameEnders startingAt: start ifAbsent: [ text size + 1].
	end _ end - 1.


	pos _ end+1.
	^text copyFrom: start to: end