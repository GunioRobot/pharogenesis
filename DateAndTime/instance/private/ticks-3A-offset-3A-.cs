ticks: ticks offset: utcOffset
	"ticks is {julianDayNumber. secondCount. nanoSeconds}"
	| normalize |

	normalize := [ :i :base | | tick div quo rem |
		tick := ticks at: i.
		div := tick digitDiv: base neg: tick negative.
		quo := div first normalize.
		rem := div second normalize.
		rem < 0 ifTrue: [ quo := quo - 1. rem := base + rem ].
		ticks at: (i-1) put: ((ticks at: i-1) + quo).
		ticks at: i put: rem ].

	normalize value: 3 value: NanosInSecond.
	normalize value: 2 value: SecondsInDay.

	jdn	_ ticks first.
	seconds	_ ticks second.
	nanos := ticks third.
	offset := utcOffset.


