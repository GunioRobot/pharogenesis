windowWithLabel: aLabel
	"Answer a SystemWindow associated with the receiver, with appropriate border characteristics"

	| window |
	"The first branch below provides a pretty nice effect -- a large draggable border when active, a minimal border when not -- but the problem is that we often rely on the title bar to convey useful information.  For the moment, whether the titled or nontitled variant is used is governed by the hard-coded preference named 'suppressWindowTitlesInInstanceBrowsers'"

	Preferences suppressWindowTitlesInInstanceBrowsers
		ifTrue:
			[(window _ SystemWindow newWithoutLabel) model: self.
			window setProperty: #borderWidthWhenActive toValue: 8.
			window setProperty: #borderWidthWhenInactive toValue: 1.
			window borderWidth: 8]
		ifFalse:
			[(window _ SystemWindow labelled: aLabel) model: self].
	^ window
