explain
	"Try to shed some light on what kind of entity the current selection is.   The selection must be a single token or construct. Insert the answer after the selection. Send private messages whose names begin with 'explain' that return a string if they recognize the selection, else nil.  NB: Put here intact from BrowserCodeController.  But there's too many things that still don't work, as the explain code was very tightly bound with properties of code browsers.  So for the moment, in the interest of system integrity, we don't permit.  "

	self flag: #deferred.   "Plenty of things make sense to explain in any text window, but my efforts to elevate the explain facility to more generic use ran out of steam before success."

	^ self inform: 'Sorry, explain is currently available
only in code panes.  Someday, it may be available
in any text pane.  Maybe.'