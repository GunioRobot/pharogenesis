Object
	subclass: #SystemMonitor
	instanceVariableNames:
		'window labels valSelectors baselineSkip minValues maxValues vmParameters gcLowWaterMark gcHighWaterMark prevAllocCount prevAllocRate prevFullGC prevDeltaFullGC prevIncrGC prevDeltaIncrGC prevMsClock prevMcMiss prevMcHit prevIcHit '
	classVariableNames:
		'ActiveClock ActiveMonitor BackgroundColor BarBackgroundColor BarBorderColor BarBorderWidth BarColors BarForegroundColor BarWidth BorderColor BorderWidth DefaultBarHeight ForegroundColor Inset MonitorDelay '
	poolDictionaries: ''
	category: 'Squeak-Interpreter'