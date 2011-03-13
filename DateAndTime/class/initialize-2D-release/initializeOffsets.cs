initializeOffsets 

	| epochianSeconds secondsSinceMidnight nowSecs  |
	 
 	LastTick := 0.
  
	nowSecs :=  self clock secondsWhenClockTicks.
	LastMilliSeconds := self millisecondClockValue. 

	epochianSeconds := Duration days: SqueakEpoch hours: 0 minutes: 0 seconds: nowSecs.

	DaysSinceEpoch := epochianSeconds days.

	secondsSinceMidnight := (epochianSeconds - (Duration days: DaysSinceEpoch hours: 0 minutes: 0 seconds: 0)) asSeconds.  

	MilliSecondOffset := (secondsSinceMidnight * 1000 - LastMilliSeconds).

	LocalOffset := nil.

 
 
