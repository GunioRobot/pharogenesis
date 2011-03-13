pageOffset
	|  offset  |

	EPSCanvas bobsPostScriptHacks ifTrue: [^0@0].		"seems like we were adding it twice"

	offset _ self pageBBox origin.
	^ (offset x @ offset y).