printStringHtml: aString on: aStream 
	| html |
	html := aString.
	""
	html := html copyReplaceAll: '&' with: '&amp;'.
	html := html copyReplaceAll: '>' with: '&gt;'.
	html := html copyReplaceAll: '<' with: '&lt;'.
	""
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬®¬¨¦Ö' with: '&aacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬®¬¨¬©' with: '&eacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬®¬¶¦ë' with: '&iacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬®¬¶¦ü' with: '&oacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬®¬¶¬ö' with: '&uacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬®¬¨¬±' with: '&ntilde;'.
	""
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬¬¶¦±' with: '&Aacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬¬¨¬¢' with: '&Eacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬¬¶¦º' with: '&Iacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬¬¨¬Æ' with: '&Oacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬¬¨¦©' with: '&Uacute;'.
	html := html copyReplaceAll: '¬¨¬®¬¨¬é¬¨¬¬¨¬·' with: '&Ntilde;'.
	""
	html := html copyReplaceAll: '
' with: '<br>
'.
	html := html copyReplaceAll: '	' with: '&nbsp;&nbsp;&nbsp;&nbsp;'.
	""
	aStream nextPutAll: html