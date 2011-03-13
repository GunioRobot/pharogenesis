chooseFrom: chooserMorph categoryItem: item

	| newKey menu |
	newKey _ item.
	self okToChange ifFalse: [^ self].
	(item = 'add new key') ifTrue:
		[newKey _ FillInTheBlank request: 'New key to use'
						initialAnswer: self categorySelected.
		newKey isEmpty ifTrue: [^ self].
		(userCategories includes: newKey) ifTrue: [^ self].
		userCategories _ (userCategories copyWith: newKey) sort].
	(item beginsWith: 'remove ') ifTrue:
		[(self confirm: 'Removal of this category will cause all items formerly
categorized as ''' , self categorySelected , ''' to be reclassified as ''all''.
Is this really what you want to do?
[unless there are very few, choose ''no'']')
			ifFalse: [^ self].
		self rekeyAllRecordsFrom: self categorySelected to: 'all'.
		userCategories _ userCategories copyWithout: self categorySelected.
		newKey _ 'all'].
	(item beginsWith: 'rename ') ifTrue:
		[menu _ CustomMenu new.
		userCategories do: [:key | menu add: key action: key].
		newKey _ menu startUpWithCaption: 'Please select the new key for
items now categorized as ''' , self categorySelected , '''.'.
		newKey ifNil: [^ self].
		(self confirm: 'Renaming this category will cause all items formerly
categorized as ''' , self categorySelected , ''' to be reclassified as ''' , newKey , '''.
Is this really what you want to do?')
			ifFalse: [^ self].
		self rekeyAllRecordsFrom: self categorySelected to: newKey.
		userCategories _ userCategories copyWithout: self categorySelected].
	self selectCategory: newKey.
	chooserMorph contentsClipped: newKey