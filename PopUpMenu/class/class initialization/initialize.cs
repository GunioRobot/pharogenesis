initialize  "PopUpMenu initialize"
	"Change CacheMenuForms to true to get faster popup menus on slower systems."
	"CacheMenuForms _ true"

	CacheMenuForms _ false.
	(MenuStyle _ TextStyle default copy)
		gridForFont: 1 withLead: 0;
		centered.
	PopUpMenu withAllSubclasses do:
		[:menuClass | menuClass allInstancesDo:
			[:m | m rescan]]
