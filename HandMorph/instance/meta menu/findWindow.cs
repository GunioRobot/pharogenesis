findWindow
	"Present a menu of window titles, and activate the one that gets chosen.
	Collapsed windows appear below line, expand if chosen."
	| menu expanded collapsed |
	menu _ MenuMorph new.
	expanded _ SystemWindow windowsIn: self world satisfying: [:w | w isCollapsed not].
	collapsed _ SystemWindow windowsIn: self world satisfying: [:w | w isCollapsed].

	expanded do: [:w | menu add: w label target: w action: #activate].
	expanded isEmpty | collapsed isEmpty ifFalse: [menu addLine].
	collapsed do: [:w | menu add: w label target: w action: #collapseOrExpand].

	self invokeMenu: menu event: lastEvent