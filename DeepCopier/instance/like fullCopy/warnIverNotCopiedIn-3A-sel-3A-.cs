warnIverNotCopiedIn: aClass sel: sel
	"Warn the user to update veryDeepCopyWith: or veryDeepInner:"

	self inform: ('An instance variable was added to to class ', aClass name, ',\and it is not copied in the method ', sel, '.\Please rewrite it to handle all instance variables.\See DeepCopier class comment.') withCRs.
	Browser openMessageBrowserForClass: aClass selector: sel editString: nil.
