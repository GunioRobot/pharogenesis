show4a

    " B3DDemoSpheres new show4a"

     | view |

  self createScene4a.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene4a;
     scene: scene.
 view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view openInSystemWindow.