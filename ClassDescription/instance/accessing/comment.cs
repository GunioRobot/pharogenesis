comment
	"Answer the receiver's comment. (If missing, supply a template) "
	| aString |
	aString _ self theNonMetaClass organization classComment.
	aString isEmpty ifFalse: [^ aString].
	^
'Main comment stating the purpose of this class and relevant relationship to other classes.

Possible useful expressions for doIt or printIt.

Structure:
 instVar1		type -- comment about the purpose of instVar1
 instVar2		type -- comment about the purpose of instVar2

Any further useful comments about the general approach of this implementation.'