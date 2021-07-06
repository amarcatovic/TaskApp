using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Notifications.Utilities.Email.HTML
{
    public class TaskCreatedEmailTemplate
    {
        public static string TaskActivationEmailTemplate(string taskTitle, DateTime finishDate)
        {
            return @"<table width='100%' cellpadding='20%'>
                        <tr>
                          <td align='center'>
                            <table padding:='10%' width='50%' cellspacing='0' cellpadding='0'
                              style='color: #999999; background-color: #F7F7F7; border-radius: 5px; overflow: hidden;'>
                              <tbody>
                                <tr>
                                  <td width='520' valign='top' align='center'>
                                    <table width='100%' cellspacing='0' cellpadding='0'>
                                      <tbody>
                                        <tr>
                                          <td>
                                            <img
                                              src='https://cdn.discordapp.com/attachments/601552355804184674/778721276729622528/bannerTop.png'
                                              alt='' width='100%' height='auto'>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td align='center'><img
                                              src='https://cdn.discordapp.com/attachments/778373009558863942/778447463085768744/placeholderLogo.png'
                                              alt='' width='100px' height='100px' style='margin:5%'></td>
                                        </tr>
                                        <tr>
                                          <td align='center'>
                                            <h2 style='margin-left: 5%; margin-right: 5%;'>You Have A new Task on TaskApp!<span style='font-weight: bold;'></span></h2>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td align='center'>
                                            <p style='margin-left: 5%; margin-right: 5%;'>Your Task:</p>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td align='center'>
                                            <h1 style='margin-left: 5%; margin-right: 5%;'>" + taskTitle + @"</h1>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td align='center'>
                                            <p
                                              style=' border-top: 1px solid #a3a3a3b2; padding-top: 2em; margin-left: 5%; margin-right: 5%;'>
                                              Planned finish date is " + finishDate.ToString() + @"
                                          </td>
                                        </tr>
                                        <tr>
                                          <td>
                                            <img
                                              src='https://cdn.discordapp.com/attachments/601552355804184674/778721275182710805/bannerBottom.png'
                                              alt='' width='100%' height='auto'>
                                          </td>
                                        </tr>
                                      </tbody>
                                    </table>
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </td>
                        </tr>
                      </table>";
        }
    }
}
