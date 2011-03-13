jumpToProject
	"Project jumpToProject"
	"Present a list of potential projects and enter the one selected."
	| menu |
menu_MenuMorph new.
menu defaultTarget: self.
	menu := self buildJumpToMenu: menu.
	menu popUpInWorld