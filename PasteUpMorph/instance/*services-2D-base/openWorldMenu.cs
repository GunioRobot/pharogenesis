openWorldMenu
	| menu |
	menu := (TheWorldMenu new adaptToWorld: self) buildWorldMenu.
	menu addTitle: Preferences desktopMenuTitle translated.
	menu openInHand