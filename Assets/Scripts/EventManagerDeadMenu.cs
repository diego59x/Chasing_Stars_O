using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EventManagerDeadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI StarName;
    public TextMeshProUGUI StarDescription;
    string[] stars = { "NEUTRON STAR", "LIGHT ECHO", "PLEIADES", "DYING STAR" , "QUINTUPLET CLUSTER", "REMNANTS OF A SUPERNOVA", "HELIX NEBULA" ,"HENIZE 206 NEBULA", "ESKIMO NEBULA", "ROSETTE NEBULA", "EAGLE NEBULA GAS PILLARS", "CATS EYE NEBULA" };
    Dictionary<string, string> starsInfo = new Dictionary<string, string>()
    {
      {"NEUTRON STAR","It is located 50,000 light-years from Earth and that flared up so brightly in December 2004 that it temporarily blinded all the x-ray satellites in space and lit up the Earth's upper atmosphere. The flare-up occurred when the star's massive, twisting magnetic field ripped open its crust, releasing an explosion of gamma rays."},
      {"LIGHT ECHO","When the red supergiant V838 Monocerotis suddenly brightened for several weeks in early 2002, it showed it was cloaked in a never-before-seen cloud structure. The burst of light reflecting off the clouds, called a light echo, was captured by the Hubble Space Telescope."},
      {"PLEIADES","An infrared image reveals clouds of dust swaddling the stars of the Seven Sisters cluster, also known as the Pleiades. The cluster, located some 400 light-years away, formed about 100 million years ago. It contains thousands of stars but gets its name from seven of its brightest members."},
      {"DYING STAR","Ground-based telescopes make the nebula pictured here look rectangular in shape, hence its name: the Red Rectangle. But images taken by the Hubble Space Telescope revealed that it should more accurately be called the 'Red X' nebula. The nebula's unique shape comes from gas and dust emitted in cone-shaped bursts from the dying star at its center. This star, which began shedding its outer layers about 14,000 years ago, will slowly become smaller and hotter and begin to release a flood of ultraviolet light."},
      {"QUINTUPLET CLUSTER","An image taken by the Hubble Space Telescope gives the clearest view ever of the Quintuplet star cluster, a massive collection of young stars 25,000 light-years from Earth but only a hundred light-years from the center of the Milky Way. The cluster's proximity to the core of our galaxy means it is destined to be ripped apart in just a few million years."},
      {"REMNANTS OF A SUPERNOVA","A supernova arranged into thousands of small, cooling knots of gas. Each clump, originally just a small fragment of the star, is tens of times larger than the diameter of our solar system."},
      {"HELIX NEBULA","The familiar eyeball shape of the Helix Nebula shows only two dimensions of this complex celestial body. But new observations suggest it may actually be composed of two gaseous disks nearly perpendicular to each other."},
      {"HENIZE 206 NEBULA","The nebula, located just outside the Milky Way in a galaxy called the Large Magellanic Cloud, offers astrophysicists a celestial ringside seat on the death and rebirth of stars."},
      {"ESKIMO NEBULA","The Eskimo Nebula got its name because the astronomer who discovered it in 1787 thought it looked like a person's head surrounded by a parka hood. This highly detailed image taken in 2000 by the Hubble Space Telescope, however, reveals a much more complex structure, one which astrophysicists are still trying to explain."},
      {"ROSETTE NEBULA","An infrared image of the Rosette Nebula shows super-hot O stars (blue dots inside spheres) amid a torrent of gas and dust (green and red). This star-forming nebula, which lies 5,000 light-years away in the constellation Monoceros, is named for its rosebud-like shape when seen using only optical light."},
      {"EAGLE NEBULA GAS PILLARS","This dark column of cool molecular hydrogen gas and dust is part of the Eagle Nebula, a star-forming region 6,500 light-years away in the constellation Serpens. In this image, taken by the Hubble Space Telescope, new stars can been seen inside fingerlike protrusions extending from the top of the nebula. Each 'fingertip' is slightly larger than our entire solar system."},
      {"CATS EYE NEBULA","The Cat's Eye Nebula contains some of the most complex gas formations astronomers have ever seen, including concentric shells, high-speed jets, and unusual shock-induced knots. Some scientists think the nebula's intricate structures suggest it is a double-star system."}
    };
    private void Start()
    {
        int starIndex = Random.Range(0, stars.Length);
        string star_name = stars[starIndex];
        StarName.text = "You hit " + star_name;
        StarDescription.text = starsInfo[star_name];
    }

    public void GameScene()
    {
        SceneManager.LoadScene("RacingStars");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("GameOver");
    }

}
