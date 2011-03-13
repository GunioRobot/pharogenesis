setShiftKeyForItems: items  startAtOffset: aStartNumber inMenu: aMenu useMgr: aMenuBarMgr
	| item |
	1 to: items size do: [:i |
		item := items at: i.
		item shift ifTrue:
			[
aMenuBarMgr setMenuItemModifiers: aMenu item: aStartNumber+i-1 inModifiers: #(#shift).]].