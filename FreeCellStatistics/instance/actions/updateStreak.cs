updateStreak
	"I moved the code from #printWins:on: and #printLosses:on: here because 
	 it is basically the same. I hope this increases the maintainability. 
	th 12/20/1999 20:41"
	currentType = #losses ifTrue: [streakLosses _ streakLosses max: currentCount].
	currentType = #wins ifTrue: [streakWins _ streakWins max: currentCount]