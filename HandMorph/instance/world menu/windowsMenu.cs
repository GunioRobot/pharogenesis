windowsMenu
	"Build the windows menu for the world."
	| menu firstFlapIndex |
	menu _ (MenuMorph entitled: 'windows & flaps...') defaultTarget: self.
	menu addStayUpItem.
	menu add: 'find window' action: #findWindow.
	menu balloonTextForLastItem: 'Presents a list of all windows; if you choose one from the list, it becomes the active window.'.

	menu add: 'find changed browsers...' action: #findDirtyBrowsers.
	menu balloonTextForLastItem: 'Presents a list of browsers that have unsubmitted changes; if you choose one from the list, it becomes the active window.'.

	menu add: 'find changed windows...' action: #findDirtyWindows.
	menu balloonTextForLastItem: 'Presents a list of all windows that have unsubmitted changes; if you choose one from the list, it becomes the active window.'.

	menu addLine.
	menu add: 'collapse all windows' action: #collapseAll.
	menu balloonTextForLastItem: 'Reduce all open windows to collapsed forms that only show titles.'.

	menu add: 'expand all windows' action: #expandAll.
	menu balloonTextForLastItem: 'Expand all collapsed windows back to their expanded forms.'.

	menu addLine.
	menu add: 'delete unchanged windows' action: #closeUnchangedWindows.
	menu balloonTextForLastItem: 'Deletes all windows that do not have unsaved text edits.'.

	menu add: 'delete non-windows' action: #deleteNonWindows.
	menu balloonTextForLastItem: 'Deletes all non-window morphs lying on the world.'.

	menu add: 'delete both of the above' action: #cleanUpWorld.
	menu balloonTextForLastItem: 'deletes all unchanged windows and also all non-window morphs lying on the world, other than flaps.'.

	menu addLine.
	menu addUpdating: #staggerPolicyString target: Preferences action: #toggleWindowPolicy.
	menu balloonTextForLastItem: 'stagger: new windows positioned so you can see a portion of each one.
tile: new windows positioned so that they do not overlap others, if possible.'.

	menu addLine; defaultTarget: Utilities.
	firstFlapIndex _ menu submorphs size.
	
	menu addUpdating: #suppressFlapsString action: #toggleFlapSuppressionInProject.
	menu balloonTextForLastItem: 'Governs whether flaps should be shown in this project'.
	menu addLine.

	menu add: 'new global flap...'  action: #addGlobalFlap.
	menu balloonTextForLastItem: 'Create a new flap that will be shared by all morphic projects'.

	menu add: 'new project flap...'  action: #addLocalFlap.
	menu balloonTextForLastItem: 'Create a new flap to be used only in this project.'.
	menu addLine.
	menu add: 'about flaps...' target: Utilities action: #explainFlaps.
	menu balloonTextForLastItem: 'Gives a window full of details about how to use flaps.'.
	menu addUpdating: #useGlobalFlapsString action: #toggleWhetherToUseGlobalFlaps.
	menu balloonTextForLastItem: 'Governs whether a universal set of "global" flaps should be used in all morphic projects that currently are showing flaps.'.

"	firstFlapIndex to: menu submorphs size do:
		[:i | (menu submorphs at: i) color: Color blue darker darker].
	The above was an experiment in making the flap-related menu items a different color.  In the ended decided it was too daring."

	^ menu