stopAndShowAll

	| prev |

self halt.	"not updated to new format"

	prev _ DEBUG.
	DEBUG _ nil.
	prev ifNil: [^Beeper beep].
	prev keysAndValuesDo: [ :k :v |
		self showStats: k from: v
	].