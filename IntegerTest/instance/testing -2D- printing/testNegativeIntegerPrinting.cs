testNegativeIntegerPrinting
	"self run: #testnegativeIntegerPrinting"

	self assert: (-2 printStringBase: 2) = '-10'.
	self assert: (-2 radix: 2) = '-10'.
	self assert: -2 printStringHex = '-2'.
	self assert: (-2 storeStringBase: 2) = '-2r10'.
	self assert: -2 storeStringHex = '-16r2'.
	self assert: (-21 printStringBase: 3) = '-210'.
	self assert: (-21 radix: 3) = '-210'.
	self assert: -21 printStringHex = '-15'.
	self assert: (-21 storeStringBase: 3) = '-3r210'.
	self assert: -21 storeStringHex = '-16r15'.
	self assert: (-228 printStringBase: 4) = '-3210'.
	self assert: (-228 radix: 4) = '-3210'.
	self assert: -228 printStringHex = '-E4'.
	self assert: (-228 storeStringBase: 4) = '-4r3210'.
	self assert: -228 storeStringHex = '-16rE4'.
	self assert: (-2930 printStringBase: 5) = '-43210'.
	self assert: (-2930 radix: 5) = '-43210'.
	self assert: -2930 printStringHex = '-B72'.
	self assert: (-2930 storeStringBase: 5) = '-5r43210'.
	self assert: -2930 storeStringHex = '-16rB72'.
	self assert: (-44790 printStringBase: 6) = '-543210'.
	self assert: (-44790 radix: 6) = '-543210'.
	self assert: -44790 printStringHex = '-AEF6'.
	self assert: (-44790 storeStringBase: 6) = '-6r543210'.
	self assert: -44790 storeStringHex = '-16rAEF6'.
	self assert: (-800667 printStringBase: 7) = '-6543210'.
	self assert: (-800667 radix: 7) = '-6543210'.
	self assert: -800667 printStringHex = '-C379B'.
	self assert: (-800667 storeStringBase: 7) = '-7r6543210'.
	self assert: -800667 storeStringHex = '-16rC379B'.
	self assert: (-16434824 printStringBase: 8) = '-76543210'.
	self assert: (-16434824 radix: 8) = '-76543210'.
	self assert: -16434824 printStringHex = '-FAC688'.
	self assert: (-16434824 storeStringBase: 8) = '-8r76543210'.
	self assert: -16434824 storeStringHex = '-16rFAC688'.
	self assert: (-381367044 printStringBase: 9) = '-876543210'.
	self assert: (-381367044 radix: 9) = '-876543210'.
	self assert: -381367044 printStringHex = '-16BB3304'.
	self assert: (-381367044 storeStringBase: 9) = '-9r876543210'.
	self assert: -381367044 storeStringHex = '-16r16BB3304'.
	self assert: (-9876543210 printStringBase: 10) = '-9876543210'.
	self assert: (-9876543210 radix: 10) = '-9876543210'.
	self assert: -9876543210 printStringHex = '-24CB016EA'.
	self assert: (-9876543210 storeStringBase: 10) = '-9876543210'.
	self assert: -9876543210 storeStringHex = '-16r24CB016EA'.
	self assert: (-282458553905 printStringBase: 11) = '-A9876543210'.
	self assert: (-282458553905 radix: 11) = '-A9876543210'.
	self assert: -282458553905 printStringHex = '-41C3D77E31'.
	self assert: (-282458553905 storeStringBase: 11) = '-11rA9876543210'.
	self assert: -282458553905 storeStringHex = '-16r41C3D77E31'.
	self assert: (-8842413667692 printStringBase: 12) = '-BA9876543210'.
	self assert: (-8842413667692 radix: 12) = '-BA9876543210'.
	self assert: -8842413667692 printStringHex = '-80AC8ECF56C'.
	self assert: (-8842413667692 storeStringBase: 12) = '-12rBA9876543210'.
	self assert: -8842413667692 storeStringHex = '-16r80AC8ECF56C'.
	self assert: (-300771807240918 printStringBase: 13) = '-CBA9876543210'.
	self assert: (-300771807240918 radix: 13) = '-CBA9876543210'.
	self assert: -300771807240918 printStringHex = '-1118CE4BAA2D6'.
	self assert: (-300771807240918 storeStringBase: 13) = '-13rCBA9876543210'.
	self assert: -300771807240918 storeStringHex = '-16r1118CE4BAA2D6'.
	self assert: (-11046255305880158 printStringBase: 14) = '-DCBA9876543210'.
	self assert: (-11046255305880158 radix: 14) = '-DCBA9876543210'.
	self assert: -11046255305880158 printStringHex = '-273E82BB9AF25E'.
	self assert: (-11046255305880158 storeStringBase: 14) = '-14rDCBA9876543210'.
	self assert: -11046255305880158 storeStringHex = '-16r273E82BB9AF25E'.
	self assert: (-435659737878916215 printStringBase: 15) = '-EDCBA9876543210'.
	self assert: (-435659737878916215 radix: 15) = '-EDCBA9876543210'.
	self assert: -435659737878916215 printStringHex = '-60BC6392F366C77'.
	self assert: (-435659737878916215 storeStringBase: 15) = '-15rEDCBA9876543210'.
	self assert: -435659737878916215 storeStringHex = '-16r60BC6392F366C77'.
	self assert: (-18364758544493064720 printStringBase: 16) = '-FEDCBA9876543210'.
	self assert: (-18364758544493064720 radix: 16) = '-FEDCBA9876543210'.
	self assert: -18364758544493064720 printStringHex = '-FEDCBA9876543210'.
	self assert: (-18364758544493064720 storeStringBase: 16) = '-16rFEDCBA9876543210'.
	self assert: -18364758544493064720 storeStringHex = '-16rFEDCBA9876543210'.
	self assert: (-824008854613343261192 printStringBase: 17) = '-GFEDCBA9876543210'.
	self assert: (-824008854613343261192 radix: 17) = '-GFEDCBA9876543210'.
	self assert: -824008854613343261192 printStringHex = '-2CAB6B877C1CD2D208'.
	self assert: (-824008854613343261192 storeStringBase: 17) = '-17rGFEDCBA9876543210'.
	self assert: -824008854613343261192 storeStringHex = '-16r2CAB6B877C1CD2D208'.
	self assert: (-39210261334551566857170 printStringBase: 18) = '-HGFEDCBA9876543210'.
	self assert: (-39210261334551566857170 radix: 18) = '-HGFEDCBA9876543210'.
	self assert: -39210261334551566857170 printStringHex = '-84D97AFCAE81415B3D2'.
	self assert: (-39210261334551566857170 storeStringBase: 18) = '-18rHGFEDCBA9876543210'.
	self assert: -39210261334551566857170 storeStringHex = '-16r84D97AFCAE81415B3D2'.
	self assert: (-1972313422155189164466189 printStringBase: 19) = '-IHGFEDCBA9876543210'.
	self assert: (-1972313422155189164466189 radix: 19) = '-IHGFEDCBA9876543210'.
	self assert: -1972313422155189164466189 printStringHex = '-1A1A75329C5C6FC00600D'.
	self assert: (-1972313422155189164466189 storeStringBase: 19) = '-19rIHGFEDCBA9876543210'.
	self assert: -1972313422155189164466189 storeStringHex = '-16r1A1A75329C5C6FC00600D'.
	self assert: (-104567135734072022160664820 printStringBase: 20) = '-JIHGFEDCBA9876543210'.
	self assert: (-104567135734072022160664820 radix: 20) = '-JIHGFEDCBA9876543210'.
	self assert: -104567135734072022160664820 printStringHex = '-567EF3C9636D242A8C68F4'.
	self assert: (-104567135734072022160664820 storeStringBase: 20) = '-20rJIHGFEDCBA9876543210'.
	self assert: -104567135734072022160664820 storeStringHex = '-16r567EF3C9636D242A8C68F4'.
	self assert: (-5827980550840017565077671610 printStringBase: 21) = '-KJIHGFEDCBA9876543210'.
	self assert: (-5827980550840017565077671610 radix: 21) = '-KJIHGFEDCBA9876543210'.
	self assert: -5827980550840017565077671610 printStringHex = '-12D4CAE2B8A09BCFDBE30EBA'.
	self assert: (-5827980550840017565077671610 storeStringBase: 21) = '-21rKJIHGFEDCBA9876543210'.
	self assert: -5827980550840017565077671610 storeStringHex = '-16r12D4CAE2B8A09BCFDBE30EBA'.
	self assert: (-340653664490377789692799452102 printStringBase: 22) = '-LKJIHGFEDCBA9876543210'.
	self assert: (-340653664490377789692799452102 radix: 22) = '-LKJIHGFEDCBA9876543210'.
	self assert: -340653664490377789692799452102 printStringHex = '-44CB61B5B47E1A5D8F88583C6'.
	self assert: (-340653664490377789692799452102 storeStringBase: 22) = '-22rLKJIHGFEDCBA9876543210'.
	self assert: -340653664490377789692799452102 storeStringHex = '-16r44CB61B5B47E1A5D8F88583C6'.
	self assert: (-20837326537038308910317109288851 printStringBase: 23) = '-MLKJIHGFEDCBA9876543210'.
	self assert: (-20837326537038308910317109288851 radix: 23) = '-MLKJIHGFEDCBA9876543210'.
	self assert: -20837326537038308910317109288851 printStringHex = '-1070108876456E0EF115B389F93'.
	self assert: (-20837326537038308910317109288851 storeStringBase: 23) = '-23rMLKJIHGFEDCBA9876543210'.
	self assert: -20837326537038308910317109288851 storeStringHex = '-16r1070108876456E0EF115B389F93'.
	self assert: (-1331214537196502869015340298036888 printStringBase: 24) = '-NMLKJIHGFEDCBA9876543210'.
	self assert: (-1331214537196502869015340298036888 radix: 24) = '-NMLKJIHGFEDCBA9876543210'.
	self assert: -1331214537196502869015340298036888 printStringHex = '-41A24A285154B026B6ED206C6698'.
	self assert: (-1331214537196502869015340298036888 storeStringBase: 24) = '-24rNMLKJIHGFEDCBA9876543210'.
	self assert: -1331214537196502869015340298036888 storeStringHex = '-16r41A24A285154B026B6ED206C6698'.
	self assert: (-88663644327703473714387251271141900 printStringBase: 25) = '-ONMLKJIHGFEDCBA9876543210'.
	self assert: (-88663644327703473714387251271141900 radix: 25) = '-ONMLKJIHGFEDCBA9876543210'.
	self assert: -88663644327703473714387251271141900 printStringHex = '-111374860A2C6CEBE5999630398A0C'.
	self assert: (-88663644327703473714387251271141900 storeStringBase: 25) = '-25rONMLKJIHGFEDCBA9876543210'.
	self assert: -88663644327703473714387251271141900 storeStringHex = '-16r111374860A2C6CEBE5999630398A0C'.
	self assert: (-6146269788878825859099399609538763450 printStringBase: 26) = '-PONMLKJIHGFEDCBA9876543210'.
	self assert: (-6146269788878825859099399609538763450 radix: 26) = '-PONMLKJIHGFEDCBA9876543210'.
	self assert: -6146269788878825859099399609538763450 printStringHex = '-49FBA7F30B0F48BD14E6A99BD8ADABA'.
	self assert: (-6146269788878825859099399609538763450 storeStringBase: 26) = '-26rPONMLKJIHGFEDCBA9876543210'.
	self assert: -6146269788878825859099399609538763450 storeStringHex = '-16r49FBA7F30B0F48BD14E6A99BD8ADABA'.
	self assert: (-442770531899482980347734468443677777577 printStringBase: 27) = '-QPONMLKJIHGFEDCBA9876543210'.
	self assert: (-442770531899482980347734468443677777577 radix: 27) = '-QPONMLKJIHGFEDCBA9876543210'.
	self assert: -442770531899482980347734468443677777577 printStringHex = '-14D1A80A997343640C1145A073731DEA9'.
	self assert: (-442770531899482980347734468443677777577 storeStringBase: 27) = '-27rQPONMLKJIHGFEDCBA9876543210'.
	self assert: -442770531899482980347734468443677777577 storeStringHex = '-16r14D1A80A997343640C1145A073731DEA9'.
	self assert: (-33100056003358651440264672384704297711484 printStringBase: 28) = '-RQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-33100056003358651440264672384704297711484 radix: 28) = '-RQPONMLKJIHGFEDCBA9876543210'.
	self assert: -33100056003358651440264672384704297711484 printStringHex = '-6145B6E6DACFA25D0E936F51D25932377C'.
	self assert: (-33100056003358651440264672384704297711484 storeStringBase: 28) = '-28rRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -33100056003358651440264672384704297711484 storeStringHex = '-16r6145B6E6DACFA25D0E936F51D25932377C'.
	self assert: (-2564411043271974895869785066497940850811934 printStringBase: 29) = '-SRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-2564411043271974895869785066497940850811934 radix: 29) = '-SRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -2564411043271974895869785066497940850811934 printStringHex = '-1D702071CBA4A1597D4DD37E95EFAC79241E'.
	self assert: (-2564411043271974895869785066497940850811934 storeStringBase: 29) = '-29rSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -2564411043271974895869785066497940850811934 storeStringHex = '-16r1D702071CBA4A1597D4DD37E95EFAC79241E'.
	self assert: (-205646315052919334126040428061831153388822830 printStringBase: 30) = '-TSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-205646315052919334126040428061831153388822830 radix: 30) = '-TSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -205646315052919334126040428061831153388822830 printStringHex = '-938B4343B54B550989989D02998718FFB212E'.
	self assert: (-205646315052919334126040428061831153388822830 storeStringBase: 30) = '-30rTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -205646315052919334126040428061831153388822830 storeStringHex = '-16r938B4343B54B550989989D02998718FFB212E'.
	self assert: (-17050208381689099029767742314582582184093573615 printStringBase: 31) = '-UTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-17050208381689099029767742314582582184093573615 radix: 31) = '-UTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -17050208381689099029767742314582582184093573615 printStringHex = '-2FC8ECB1521BA16D24A69E976D53873E2C661EF'.
	self assert: (-17050208381689099029767742314582582184093573615 storeStringBase: 31) = '-31rUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -17050208381689099029767742314582582184093573615 storeStringHex = '-16r2FC8ECB1521BA16D24A69E976D53873E2C661EF'.
	self assert: (-1459980823972598128486511383358617792788444579872 printStringBase: 32) = '-VUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-1459980823972598128486511383358617792788444579872 radix: 32) = '-VUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -1459980823972598128486511383358617792788444579872 printStringHex = '-FFBBCDEB38BDAB49CA307B9AC5A928398A418820'.
	self assert: (-1459980823972598128486511383358617792788444579872 storeStringBase: 32) = '-32rVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -1459980823972598128486511383358617792788444579872 storeStringHex = '-16rFFBBCDEB38BDAB49CA307B9AC5A928398A418820'.
	self assert: (-128983956064237823710866404905431464703849549412368 printStringBase: 33) = '-WVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-128983956064237823710866404905431464703849549412368 radix: 33) = '-WVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -128983956064237823710866404905431464703849549412368 printStringHex = '-584120A0328DE272AB055A8AA003CE4A559F223810'.
	self assert: (-128983956064237823710866404905431464703849549412368 storeStringBase: 33) = '-33rWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -128983956064237823710866404905431464703849549412368 storeStringHex = '-16r584120A0328DE272AB055A8AA003CE4A559F223810'.
	self assert: (-11745843093701610854378775891116314824081102660800418 printStringBase: 34) = '-XWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-11745843093701610854378775891116314824081102660800418 radix: 34) = '-XWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -11745843093701610854378775891116314824081102660800418 printStringHex = '-1F64D4FC76000F7B92CF0CD5D0F350139AB9F25D8FA2'.
	self assert: (-11745843093701610854378775891116314824081102660800418 storeStringBase: 34) = '-34rXWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -11745843093701610854378775891116314824081102660800418 storeStringHex = '-16r1F64D4FC76000F7B92CF0CD5D0F350139AB9F25D8FA2'.
	self assert: (-1101553773143634726491620528194292510495517905608180485 printStringBase: 35) = '-YXWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-1101553773143634726491620528194292510495517905608180485 radix: 35) = '-YXWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -1101553773143634726491620528194292510495517905608180485 printStringHex = '-B8031AD55AD1FAA89E07A271CA1ED2F420415D1570305'.
	self assert: (-1101553773143634726491620528194292510495517905608180485 storeStringBase: 35) = '-35rYXWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -1101553773143634726491620528194292510495517905608180485 storeStringHex = '-16rB8031AD55AD1FAA89E07A271CA1ED2F420415D1570305'.
	self assert: (-106300512100105327644605138221229898724869759421181854980 printStringBase: 36) = '-ZYXWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: (-106300512100105327644605138221229898724869759421181854980 radix: 36) = '-ZYXWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -106300512100105327644605138221229898724869759421181854980 printStringHex = '-455D441E55A37239AB4C303189576071AF5578FFCA80504'.
	self assert: (-106300512100105327644605138221229898724869759421181854980 storeStringBase: 36) = '-36rZYXWVUTSRQPONMLKJIHGFEDCBA9876543210'.
	self assert: -106300512100105327644605138221229898724869759421181854980 storeStringHex = '-16r455D441E55A37239AB4C303189576071AF5578FFCA80504'.