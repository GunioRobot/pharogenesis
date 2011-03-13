openForServices
	"PreferenceBrowser openForServices"
	| browser |
	browser := self new.
	browser initializeForServices.
	(ServiceBrowserMorph withModel: browser)
		openInWorld.
	^browser.	