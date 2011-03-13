flapsMenu
	"Build the flaps menu for the world."

	| aMenu |
	aMenu _ UpdatingMenuMorph new updater: self updateSelector: #formulateFlapsMenu:.
	self formulateFlapsMenu: aMenu.
	^ aMenu