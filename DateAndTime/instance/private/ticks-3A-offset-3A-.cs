ticks: ticks offset: utcOffset
	"ticks is {julianDayNumber. secondCount. nanoSeconds}"

	self normalize: 3 ticks: ticks base: NanosInSecond.
	self normalize: 2 ticks: ticks base: SecondsInDay.

	jdn	_ ticks at: 1.
	seconds	_ ticks at: 2.
	nanos := ticks at: 3.
	offset := utcOffset