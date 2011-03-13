openForServices
	"PreferenceBrowser openForServices"
	| browser |
	browser _ self new.
	browser initializeForServices.
	(ServiceBrowserMorph withModel: browser)
		openInWorld.
	^browser.	