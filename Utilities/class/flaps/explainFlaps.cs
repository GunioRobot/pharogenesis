explainFlaps
	"Open a window giving flap  help."
	"Utilities explainFlaps"
	| aString |
	aString _ 
'Flaps are like drawers on the edge of the screen, which can be opened so that you can use what is inside them, and closed when you do not need them.  They have many possible uses, a few of which are illustrated by the default set of flaps you can get as described below.

"Global flaps" are available in every morphic project.  As you move from project to project, you will see the same flaps in each.   To get started using global flaps, set the "useGlobalFlaps" Preference to true, or choose "start using global flaps" from the windows/flaps menu.

"Project flaps" are flaps that belong to a single morphic project.

If a flap is set up as a parts bin (such as the default Tools and Supplies flaps), you can use it to create new objects -- just mouse-over the tab so that the flap will open up, then find the object you want, and drag it; when the cursor leaves the flap, the flap itself will disappear, and you''ll be left holding the new object -- just click to place it exactly where you want it.

If a flap is *not* set up as a parts bin (such as the default "Squeak" flap at the left edge of the screen) you can park objects there (this is an easy way to move objects from project to project) and you can place your own private controls there, etc.  Everything in the default "Squeak" flap (and all the other default flaps, for that matter) is there only for illustrative purposes -- every user will want to fine-tune the flaps to suit his/her own style and needs.

Each flap may be set up to appear on mouseover, dragover, both, or neither.  See the menu items described below for more about these and other options.

You can open a closed flap by clicking on its tab, or by dragging the tab toward the center of the screen

You can close an open flap by clicking on its tab or by dragging the tab back off the edge of the screen.

Drag the tab of a flap to reposition the tab and to resize the flap itself.  Repositioning starts when you drag the cursor out of the original tab area.

If flaps or their tabs seem wrongly positioned or lost, try issuing a restoreDisplay from the screen menu.

The red-halo menu on a flap gives you access to the "flap..." submenu which allows you to change its properties.   For greatest ease of use, request "keep this menu up" here -- that way, you can easily explore all the options in the menu.

tab color...				Lets you change the color of the flap''s tab.
flap color...				Lets you change the color of the flap itself.

use textual tab...		If the tab is not textual, makes it become textual.
change tab wording...	If the tab is already textual, allows you to edit
							its wording.

use graphical tab...		If the tab is not graphical, makes it become
							graphical.
choose tab graphic...	If the tab is already graphical, allows you
							to change the picture.

use solid tab...			If the tab is not solid, makes it become solid, i.e.
							appear as a solid band of color along the
							entire length or width of the screen.

parts-bin behavior		If set, then dragging an object from the flap
							tears off a new copy of the object.

dragover				If set, the flap opens on dragover and closes
							again on drag-leave.

mouseover				If set, the flap opens on mouseover and closes
							again on mouse-leave. 

cling to edge...			Governs which edge (left, right, top, bottom)
							the flap adheres to.

destroy this flap		Deletes the flap.

To define a new flap, use "new global flap..." or "new project flap...", found in the "windows and flaps" menu.

To reinstate the default system flaps, evaluate "Utilities reinstateDefaultFlaps"  (caveat -- this will first remove all existing flaps, including any that you may have manually added or edited.)

If flaps that you wish to use appear to be buried behind other objects on your screen, simply clicking on the desktop background will bring all flap tabs to the front.

To add, delete, or edit things on a given flap, it is often wise first to suspend the flap''s mouse-over and drag-over sensitivity, so it won''t keep disappearing on you while you''re trying to work with it.

The "Menu" flap provided in the default flap-set provides a service that will be valuable to some (it gives a sense of place to many standard menu item, and allows you to avoid navigating through submenus) and dismaying to others (who should destroy the flap immediately -- do this by bringing up the red-halo menu for the "Menu" tab, and then choosing "destroy this flap").

'.
	
  

	(StringHolder new contents: aString)
		openLabel: 'Flaps in Morphic'

	