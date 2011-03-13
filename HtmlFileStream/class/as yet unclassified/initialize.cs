initialize   "HtmlFileStream initialize"
	TabThing _ String
		with: (Character value: 1)
		with: (Character value: 32)
		with: (Character value: 1)
		with: (Character value: 32)
"Maybe this should be a tab char followed by four '&nbsp' non-breakable spaces.  That way, the nextPut: method in this class could file in correctly from html (it has a $tab).  Using #(1 32 1 32) has the advantage of looking nice in a text editor of file list."