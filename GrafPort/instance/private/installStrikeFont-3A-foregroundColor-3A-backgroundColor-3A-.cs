installStrikeFont: aStrikeFont foregroundColor: foregroundColor backgroundColor: backgroundColor
	super installStrikeFont: aStrikeFont foregroundColor: foregroundColor backgroundColor: backgroundColor.
	alpha _ foregroundColor privateAlpha.
	"dynamically switch between blend modes to support translucent text"
	"To handle the transition from TTCFont to StrikeFont, rule 34 must be taken into account."
	alpha = 255 ifTrue:[
		combinationRule = 30 ifTrue: [combinationRule _ Form over].
		combinationRule = 31 ifTrue: [combinationRule _ Form paint].
		combinationRule = 34 ifTrue: [combinationRule _ Form paint].
	] ifFalse:[
		combinationRule = Form over ifTrue: [combinationRule _ 30].
		combinationRule = Form paint ifTrue: [combinationRule _ 31].
		combinationRule = 34 ifTrue: [combinationRule _ 31].
	].
	lastFont _ aStrikeFont.
	lastFontForegroundColor _ foregroundColor.
	lastFontBackgroundColor _ backgroundColor.
