shouldUsePluginAPI
	"HTTPClient shouldUsePluginAPI" 

	self isRunningInBrowser
		ifFalse: [^false].
	self browserSupportsAPI
		ifFalse: [^false].
	"The Mac plugin calls do not work in full screen mode"
	^((SmalltalkImage current  platformName = 'Mac OS')
		and: [ScreenController lastScreenModeSelected]) not